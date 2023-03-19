using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//THIS VIDEO WAS A BIG HELP https://www.youtube.com/watch?v=JVbr7osMYTo


//TODO:
//1. Finish Level 1 - Add More Enemies and Spawn Fields
//1. a) Figure out how to do bossfight - maybe just play cutscene
//2. Add some sound effects to missile impacts and other explosions
//3. Create a main menu screen
//4. Create a better UI showing health, missiles, boost, etc.
//5. Create powerups for player to pick up
//6. Create more levels.
//7. Create death animation for player
//8. Make missile lock work
//9. Make indicator to show when enemy is hit  
//10. Add visual effects for boost/brake (change afterburner length)
//11. Add a pause menu


public class Player : MonoBehaviour
{
    private Transform Model;
    private Transform FirePoint;

    private Transform closeCrosshair;
    private Vector3 closeCrosshairDefault = new Vector3(0, 0, 10);

    GameObject firedMissile;

    private Transform farCrosshair;
    public GameObject farCrossCanvas;
    //public Collider crosshairCollider;

    public Camera cam;
    //creating the container for the playerUI
    UIController playerUI; 
    //setting up the player's health val
    public float playerHealth = 10000f;
    private float abilityTime = 100f;
    float abilityRechargeCooldown = 5.0f;
    float abilityLastUsed = 0.0f;
    int score = 0;

    public float fireRate = 0.15F;
    private float nextFire = 0.0F;
    private int missileCount = 300;
    private Vector3 lockOnCoordinates;
    private bool lockedOn;
    private bool missileFired = false;


    //Making the missile and bullet objects
    public GameObject missile;
    public GameObject bullet;


    [Header("Parameters")]
    public float Speed = 30f;
  
    // Start is called before the first frame update
    void Start()
    {

        //So that I don't move off screen while testing
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        cam = Camera.main;
        //Gets the playermodel mesh as a seperate Transform
        Model = this.gameObject.transform.GetChild(0);
        FirePoint = this.gameObject.transform.GetChild(1);
        closeCrosshair = this.gameObject.transform.GetChild(2);
        farCrosshair = this.gameObject.transform.GetChild(3);
        //Linking the playerUI to the UI script, look for ways to optimize this
        playerUI = GameObject.Find("UIDocument").GetComponent<UIController>();
       

    }
  
    // Update is called once per frame

    void Update()
    {

        /*FirePoint.rotation = Model.rotation;*/


        /*aim = GameObject.Find("/Canvas/Crosshair").transform.position;
        transform.LookAt(aim);*/

        /*float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");*/

        //Controls using WASD
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        /* Code for knife flying left or right, LeanTween is awesome for this */
        //TODO FIX ANIMATION ON THIS

        if (Input.GetKey("e")){
            LeanTween.rotateZ(Model.gameObject, -90, 0.2f);

        }

        if (Input.GetKeyUp("e"))
        {
            LeanTween.rotateZ(Model.gameObject, 0, 0.2f);
        }

        if (Input.GetKey("q"))
        {
            //transform.Rotate(0, 0, 90);
            LeanTween.rotateZ(Model.gameObject, 90, 0.2f); 
        }

        if (Input.GetKeyUp("q"))
        {
            LeanTween.rotateZ(Model.gameObject, 0, 0.2f);
        }

        /* if (!Input.GetKey("q") && !Input.GetKey("e"))
         {
             LeanTween.rotateZ(gameObject, 0, 0.2f);
         }*/

        /* Do a barrel roll! */
        if (Input.GetKeyDown("z"))
        {
            LeanTween.rotateAroundLocal(Model.gameObject, Vector3.forward, 360f, 0.4f);

        }

        if (Input.GetKey("space"))
        {
            BoostZoomOut(true);
        }
        else if (Input.GetKeyUp("space"))
        {
            BoostZoomOut(false);
        }
        if (Input.GetKey("c"))
        {
            BrakeZoomIn(true);
        }
        else if (Input.GetKeyUp("c"))
        {
            BrakeZoomIn(false);
        }

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            Instantiate(bullet, FirePoint.position, FirePoint.rotation);
            nextFire = Time.time + fireRate;
        }



        if (Input.GetButtonDown("Fire2") && missileCount > 0)
        {
            firedMissile = Instantiate(missile, FirePoint.position, FirePoint.rotation);
            missileCount--;
           
        }

        Move(horizontal, vertical, 10);
        HorizontalLean(Model, horizontal, 60, 0.2f);
        //Option to turn on yaw pitching, looks mid
        //yawLean(transform, horizontal, 15, 0.5f);
        VerticalLean(Model, -vertical, 40, 0.2f);
        crosshairLockOn();
        abilityRecharge();

    }

    private void LateUpdate()
    {
        Clamp(closeCrosshair.transform);
        Clamp(transform);
    }


    void Move(float x, float y, float s)
    {

        closeCrosshair.transform.localPosition += new Vector3(x, -y, 0) * s * Time.deltaTime;
        transform.localPosition += new Vector3(closeCrosshair.transform.localPosition.x, closeCrosshair.transform.localPosition.y, 0) * 2 * Time.deltaTime;

        if (x == 0f && y == 0f)
        {
            closeCrosshair.localPosition = Vector3.Lerp(closeCrosshair.localPosition, closeCrosshairDefault, 3 * Time.deltaTime);
            //I commented this line out because I didn't know what it was doing and it fixed the dolly track bug.
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, Time.deltaTime * 1f);
        }

        var lookPos = closeCrosshair.transform.position - Model.transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);

        Model.rotation = Quaternion.Slerp(Model.transform.rotation, rotation, Time.deltaTime * 2.75f);

        //transform.LookAt(closeCrosshair.transform);

        //Model.LookAt(closeCrosshair.transform);

        FirePoint.LookAt(closeCrosshair.transform);
        //Model.rotation = FirePoint.rotation;


    }


    void crosshairLockOn()
    {
        RaycastHit hit;

        if (Physics.Raycast(FirePoint.transform.position, FirePoint.transform.forward, out hit))
        {
            if (hit.collider)
            {
                farCrosshair.transform.position = hit.point;
            }


        }

        //Making a layercast to ignore the "IgnoreRaycast layer and HitPlane layer
        //If the layercast wasnt there, it the ray would collide with the player or the hitplane
        int mask1 = 1 << LayerMask.NameToLayer("Ignore Raycast");
        int mask2 = 1 << LayerMask.NameToLayer("HitPlane");
        int mask = mask1 | mask2;


        //Shoots a raycast in the direction of the far crosshair relative to the screen
        Ray ray = cam.ScreenPointToRay(farCrossCanvas.GetComponent<RectTransform>().position);
        if (Physics.Raycast(ray, out hit, 200, ~mask))
        {

            Debug.DrawLine(ray.origin, hit.point);
            //Debug.Log(hit.transform.tag);



            if (hit.transform.tag == ("Enemy"))
            {
                //lockedOn = true;
                farCrossCanvas.GetComponent<Image>().color = Color.red;
                //lockOnCoordinates = hit.point;
            }
            else if (hit.transform.tag != "Enemy")
            {
                farCrossCanvas.GetComponent<Image>().color = Color.white;
            }

        }
        else //if nothing is hit by the raycast
        {
            farCrossCanvas.GetComponent<Image>().color = Color.white;
        }
    }

    //https://answers.unity.com/questions/799656/how-to-keep-an-object-within-the-camera-view.html
    void Clamp(Transform target) 
    {

        Vector3 pos = Camera.main.WorldToViewportPoint(target.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        target.position = Camera.main.ViewportToWorldPoint(pos);

     

    }

    void HorizontalLean(Transform target, float axis, float leanLimit, float lerpTime)
    {
        Vector3 targetEulerAngels = target.localEulerAngles;
        target.localEulerAngles = new Vector3(targetEulerAngels.x, targetEulerAngels.y, Mathf.LerpAngle(targetEulerAngels.z, -axis * leanLimit, lerpTime));
   

    }

    void VerticalLean(Transform target, float axis, float leanLimit, float lerpTime)
    {
        Vector3 targetEulerAngles = target.localEulerAngles;
        target.localEulerAngles = new Vector3(Mathf.LerpAngle(targetEulerAngles.x, -axis * leanLimit, lerpTime), targetEulerAngles.y, targetEulerAngles.z);
    }

    void yawLean(Transform target, float axis, float leanLimit, float lerpTime)
    {
        Vector3 targetEulerAngels = target.localEulerAngles;
        target.localEulerAngles = new Vector3(targetEulerAngels.x, Mathf.LerpAngle(targetEulerAngels.y, axis * leanLimit, lerpTime), targetEulerAngels.z);
    }

    void abilityRecharge()
    {
        if(abilityLastUsed + abilityRechargeCooldown < Time.time)
        {
            if (abilityTime < 100f)
            {
                abilityTime += 0.2f;
                playerUI.updateAbility(abilityTime);
            }
        }
    }

    
    public void BrakeZoomIn(bool status)
    {
        if (status && abilityTime > 0)
        {
            //cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60, Time.deltaTime * 2f);
            //cam.transform.localPosition = new Vector3(0, 0, -6f);
            
            gameObject.GetComponentInParent<Cinemachine.CinemachineDollyCart>().m_Speed = 20f;

          

            abilityTime += -0.1f;
            playerUI.updateAbility(abilityTime);
            abilityLastUsed = Time.time;
            

        }
        else
        {
           //cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 110, Time.deltaTime  * 2f);
           //cam.transform.localPosition = new Vector3(0, 0, -8f);
            gameObject.GetComponentInParent<Cinemachine.CinemachineDollyCart>().m_Speed = 50f;

            
        }
    }

    public void BoostZoomOut(bool status)
    {
        if (status && abilityTime > 0)
        {
            //cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 120, Time.deltaTime);
            //cam.transform.localPosition = new Vector3(0,0,-12f);
            
           gameObject.GetComponentInParent<Cinemachine.CinemachineDollyCart>().m_Speed = 90f;

           abilityTime += -0.1f;
           playerUI.updateAbility(abilityTime);
           abilityLastUsed = Time.time;

           

        }
        else
        {
            //cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 110, Time.deltaTime);
            //cam.transform.localPosition = new Vector3(0, 0, -8f);
            gameObject.GetComponentInParent<Cinemachine.CinemachineDollyCart>().m_Speed = 50f;

           

        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        updateHealth(-50f);
    }
    public void updateHealth(float damage)
    {

        playerHealth += damage;
        playerUI.updateHealth(playerHealth);


        if (playerHealth <= 0)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }   


}
