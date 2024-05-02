using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class PlayerShot : MonoBehaviour
{
    //singleton
   /* private static PlayerShot _instance;
    public static PlayerShot Instance
    {
        get { return _instance; }
    }*/
    //singleton



    private GameObject storagePoint;
    private GameObject basketBall;

    private Vector3 storagePos;

    private float velocityMult = 20f;

    

    private void Awake()
    {
        //singleton
       /*if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            print("slaughtered");
        }
        else
        {
            _instance = this;
            print("set yo");
        }*/
        //singleton

        storagePoint = GameObject.Find("BallStorage");
        storagePos = storagePoint.transform.position;
        basketBall = GameObject.Find("ball");
        basketBall.GetComponent<Rigidbody>().isKinematic = true;
        
    }

    private void Shooting()
    {
        basketBall.GetComponent<Rigidbody>().isKinematic = true;
    }



    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shooting();
        }

        //If slingshot is not in aiming mode dont run this code
        //if (!shootingMode) return;

        //get the current mouse position in 2d screenspace
        Vector3 mousePos2D = Input.mousePosition;

        //convert that to 3d world space
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousPos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //find the delta from the launch pos to wherever the mouse is
        Vector3 mouseDelta = mousPos3D - storagePos;

        //lets limit the mouseDelta value to some radius
        float maxMagnitude = this.GetComponent<CapsuleCollider>().radius;

        if (mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }
        
        //we calculated the new position
        //move the projectile to this new position
        //Vector3 ballPos = storagePos + mouseDelta;
        //basketBall.transform.position = ballPos;
        

        //lets fire that thing now
       if (Input.GetMouseButtonUp(0))
        {
            //print("shot");
            //LMB was released
            //no more aiming mode
            GameObject.Find("ball").GetComponent<Ball>().inHands = false;
            GameObject.Find("Player Container").GetComponent<Spawner>().shotBall = true;
            //TELL PROJECTILE TO LISTEN TO PHYSICS SYSTEM
            basketBall.GetComponent<Rigidbody>().isKinematic = false;

            //lets shoot that thing
            basketBall.GetComponent<Rigidbody>().velocity = -mouseDelta * velocityMult;

            //NOTE GAMEOBJECTS BETWEEN SCRIPTS
            //tell the camera to follow the projectile
            //FollowCam.Instance.poi = basketBall;

            // slingshot has to forget about the projectile for future projectiles
            //basketBall = null;
        }
        
    }
}
