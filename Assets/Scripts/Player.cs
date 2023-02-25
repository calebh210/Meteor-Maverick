using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS VIDEO WAS A BIG HELP https://www.youtube.com/watch?v=JVbr7osMYTo


//TODO:
// 1. Fix crosshair/make crosshair more accuruate
// 2. Make crosshair controls more fluid / switch to using WASD instead of mouse
// 3. Make collision with terrain/enemies more like starfox (bounce off/phase through and take damage, doesn't mess with controls)
// 4. Make enemies move and fire back
// 5. Set up GitHub

public class Player : MonoBehaviour
{
    private Transform Model;
    private Transform FirePoint;
    public Camera cam;



    //creating the container for the playerUI
    UIController playerUI; 
    //setting up the player's health val
    public float playerHealth = 100f;

    public float fireRate = 0.25F;
    private float nextFire = 0.0F;



    //Making the missile and bullet objects
    public GameObject missile;
    public GameObject bullet;
    private Vector3 aim;
    [Header("Parameters")]
    public float Speed = 30f;
  
    // Start is called before the first frame update
    void Start()
    {

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        cam = Camera.main;
        FirePoint = this.gameObject.transform.GetChild(1);

        //Gets the playermodel mesh as a seperate Transform
        //Doing this so that rotating the model doesn't affect control
        Model = this.gameObject.transform.GetChild(0);

        //Linking the playerUI to the UI script, look for ways to optimize this
        playerUI = GameObject.Find("UIDocument").GetComponent<UIController>();

    }
  
    // Update is called once per frame

    void Update()
    {

        FirePoint.rotation = Model.rotation;
        
        /*Vector3 mousePos = Input.mousePosition;
        mousePos += Camera.main.transform.forward * -10f;
        aim = Camera.main.ScreenToWorldPoint(mousePos);
        FirePoint.LookAt(aim);*/

        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");

        /* Code for knife flying left or right, LeanTween is awesome for this */

        if (Input.GetKey("e")){
            LeanTween.rotateZ(Model.gameObject, -90, 0.2f);

        }
        if (Input.GetKeyUp("e"))
        {
            LeanTween.rotateZ(Model.gameObject ,0, 0.1f);
        }

        if (Input.GetKey("q"))
        {
            //transform.Rotate(0, 0, 90);
            LeanTween.rotateZ(Model.gameObject, 90, 0.2f);
        }
        if (Input.GetKeyUp("q"))
        {
            /*LeanTween.rotateZ(Model.gameObject, 0, 0.1f);*/
        }

        /* Do a barrel roll! */
        if (Input.GetKeyDown("z"))
        {
            LeanTween.rotateAroundLocal(Model.gameObject, Vector3.forward, 360f, 0.4f);

            //Add code for barrel roll here
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
            GameObject firedBullet = Instantiate(bullet, FirePoint.position, FirePoint.rotation);
            firedBullet.transform.Rotate(90, 0, 0);
            firedBullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, 5000f));
            nextFire = Time.time + fireRate;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            GameObject firedMissile = Instantiate(missile, FirePoint.position, FirePoint.rotation);
            //firedMissile.transform.Rotate(90, 0, 0);
            //firedMissile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (0, 0, 5000f));


        }

   

        Move(horizontal, vertical, Speed);
        //on rail settings
        HorizontalLean(Model, horizontal, 60, 0.2f);
        yawLean(Model, horizontal, 35, 0.3f);
        VerticalLean(Model, vertical, 50, 0.2f);

       //updateHealth(-1f);


    }

    private void LateUpdate()
    {
        Clamp();
    }

    void Move(float x, float y, float s)
    {
        transform.localPosition += new Vector3(x, y, 0) * s * Time.deltaTime;
        

    }

    //https://answers.unity.com/questions/799656/how-to-keep-an-object-within-the-camera-view.html
    void Clamp() 
    {
/*
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);*/


        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.1f, 0.9f);
        pos.y = Mathf.Clamp(pos.y, 0.1f, 0.9f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);


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
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 35, 0.5f);
            //cam.fieldOfView = 110f;
            gameObject.GetComponentInParent<Cinemachine.CinemachineDollyCart>().m_Speed = 3f;

        }
        else
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60, 0.5f);
            //cam.fieldOfView = 60f;
            gameObject.GetComponentInParent<Cinemachine.CinemachineDollyCart>().m_Speed = 5f;

        }
    }

    public void BoostZoomOut(bool status)
    {
        if (status)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 110, 0.5f);
            //cam.fieldOfView = 110f;
            gameObject.GetComponentInParent<Cinemachine.CinemachineDollyCart>().m_Speed = 15f;

        }
        else
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60, 0.5f);
            //cam.fieldOfView = 60f;
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
