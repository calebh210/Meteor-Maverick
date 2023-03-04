using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS VIDEO WAS A BIG HELP https://www.youtube.com/watch?v=JVbr7osMYTo


//TODO:
// 1. Fix crosshair/make crosshair more accuruate
// 2. Make crosshair controls more fluid / switch to using WASD instead of mouse
// 3. Make collision with terrain/enemies more like starfox (bounce off/phase through and take damage, doesn't mess with controls)
// 4. Make enemies move and fire back
// 5. Add UI Elements showing boost, missiles, and other features
// 6. Change boost and brake to move cam distance not FOV
// 7. Add SFX to explosion https://freesound.org/people/derplayer/sounds/587186/

public class Player : MonoBehaviour
{
    private Transform Model;
    private Transform FirePoint;

    private Transform closeCrosshair;
    private Vector3 closeCrosshairDefault = new Vector3(0, 0, 10);

    private Transform farCrosshair;
    public Collider crosshairCollider;

    public Camera cam;

    private Vector2 crosshairLimits = new Vector2(2, 2);


    //creating the container for the playerUI
    UIController playerUI; 
    //setting up the player's health val
    public float playerHealth = 100f;

    public float fireRate = 0.25F;
    private float nextFire = 0.0F;



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
        crosshairCollider = GetComponent<BoxCollider>();
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
            LeanTween.rotateZ(gameObject, -90, 0.2f);

        }

        if (Input.GetKeyUp("e"))
        {
            LeanTween.rotateZ(gameObject, 0, 0.2f);
        }

        if (Input.GetKey("q"))
        {
            //transform.Rotate(0, 0, 90);
            LeanTween.rotateZ(gameObject, 90, 0.2f);
        }

       /* if (!Input.GetKey("q") && !Input.GetKey("e"))
        {
            LeanTween.rotateZ(gameObject, 0, 0.2f);
        }*/

        /* Do a barrel roll! */
        if (Input.GetKeyDown("z"))
        {
            LeanTween.rotateAroundLocal(gameObject, Vector3.forward, 360f, 0.4f);

        }

        if (Input.GetKeyDown("space"))
        {
            BoostZoomOut(true);
        }
        if (Input.GetKeyUp("space"))
        {
            BoostZoomOut(false);
        }
        if (Input.GetKeyDown("c"))
        {
            BrakeZoomIn(true);
        }
        if (Input.GetKeyUp("c"))
        {
            BrakeZoomIn(false);
        }

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            Instantiate(bullet, FirePoint.position, FirePoint.rotation);
            nextFire = Time.time + fireRate;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(missile, FirePoint.position, FirePoint.rotation);
  
        }

   

        Move(horizontal, vertical, 10);
        //MoveCrosshair(horizontal, vertical, 20);

        HorizontalLean(Model, horizontal, 60, 0.2f);

        //Option to turn on yaw pitching, looks mid
        //yawLean(transform, horizontal, 15, 0.5f);
        VerticalLean(Model, -vertical, 40, 0.2f);


      



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
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, Time.deltaTime * 1f);
        }

        var lookPos = closeCrosshair.transform.position - Model.transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
      
        Model.transform.rotation = Quaternion.Slerp(Model.transform.rotation, rotation, Time.deltaTime * 1.75f);

        //transform.LookAt(closeCrosshair.transform);
        FirePoint.LookAt(closeCrosshair.transform);


        RaycastHit hit;

        if (Physics.Raycast(FirePoint.transform.position, FirePoint.transform.forward, out hit))
        {
            if (hit.collider)
            {
                farCrosshair.transform.position = hit.point;
            }
        }




    }

    void MoveCrosshair(float x, float y, float s)
    {

        if( x == 0f && y == 0f)
        {
            closeCrosshair.localPosition = Vector3.Lerp(closeCrosshair.localPosition, closeCrosshairDefault, 3*Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, Time.deltaTime * 3f);
            
           
        }
        else
        {

            closeCrosshair.localPosition += new Vector3(x, -y, 0) * s * Time.deltaTime;

            Vector3 pos = Camera.main.WorldToViewportPoint(closeCrosshair.transform.position);
            pos.x = Mathf.Clamp01(pos.x);
            pos.y = Mathf.Clamp01(pos.y);
            closeCrosshair.transform.position = Camera.main.ViewportToWorldPoint(pos);



            //this isnt working - fix this
            if (transform.rotation.y > -45 && transform.rotation.y < 45)
            {
                
                //rotating ship to look at crosshair
                var lookPos = closeCrosshair.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 1f);
            }
            else
            {
                Debug.Log("hit bound");
            }
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


    
    public void BrakeZoomIn(bool status)
    {
        if (status)
        {
            //cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 35, 0.5f);
            cam.transform.localPosition = new Vector3(0, 0, -6f);
            gameObject.GetComponentInParent<Cinemachine.CinemachineDollyCart>().m_Speed = 3f;

        }
        else
        {
           //cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60, 0.5f);
            cam.transform.localPosition = new Vector3(0, 0, -8f);
            gameObject.GetComponentInParent<Cinemachine.CinemachineDollyCart>().m_Speed = 5f;

        }
    }

    public void BoostZoomOut(bool status)
    {
        if (status)
        {
            //cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 110, 0.5f);
            cam.transform.localPosition = new Vector3(0,0,-12f);
            gameObject.GetComponentInParent<Cinemachine.CinemachineDollyCart>().m_Speed = 30f;

        }
        else
        {
            //cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60, 0.5f);
            cam.transform.localPosition = new Vector3(0, 0, -8f);
            gameObject.GetComponentInParent<Cinemachine.CinemachineDollyCart>().m_Speed = 5f;

        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("crashed");
        updateHealth(-50f);
    }
    void updateHealth(float damage)
    {

        playerHealth += damage;
        playerUI.updateHealth(playerHealth);
        if (playerHealth <= 0)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }   


}
