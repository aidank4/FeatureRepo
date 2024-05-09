using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Kelly, Aidan
/// 05/08/2024
/// Controls player shooting
/// </summary>

public class PlayerShot : MonoBehaviour
{
    public GameObject storagePoint;
    public GameObject basketBall;
    public GameObject spawner;

    private Vector3 originalStoragePos;
    private Vector3 newStoragePos;

    private float velocityMult = 10f;

    //timer
    private Stopwatch stopWatch = new Stopwatch();

    /// <summary>
    /// When player begins their shot position is stored and a timer begins
    /// </summary>
    private void Shooting()
    {
        //start timer for speed calculation
        stopWatch.Start();
        //record position for delta
        originalStoragePos = storagePoint.transform.position;
    }

    /// <summary>
    /// Player has shot, a speed of the shot is decided and the ball physics are enabled
    /// </summary>
    private void Shot()
    {
        newStoragePos = storagePoint.transform.position;
        //delta between starting and ending shot form
        Vector3 mouseDelta = newStoragePos - originalStoragePos;
        stopWatch.Stop();
        long elapsed_time = stopWatch.ElapsedMilliseconds;
        //reset timer
        stopWatch.Reset();
        //took to long dont shoot/pumpfake
        if (elapsed_time > 3000) { return; }
        //calculate speed for how quick player shot
        float timeRatio = (float)(elapsed_time - 50) / 3000;
        float speedRatio = 1 - timeRatio;
        //ball is out of our hands so it should be un childed
        basketBall.GetComponent<Ball>().inHands = false;
        //print a shot taken in UI
        basketBall.GetComponent<Ball>().shotsTaken += 1;
        //tell the spawner weve shot
        spawner.GetComponent<Spawner>().shotBall = true;
        //turn the physics back on
        basketBall.GetComponent<Rigidbody>().isKinematic = false;
        //shoot the ball
        basketBall.GetComponent<Rigidbody>().velocity = mouseDelta * (speedRatio * velocityMult);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && basketBall.GetComponent<Ball>().inHands == true)
        {
            Shooting();
        }

        if (Input.GetMouseButtonUp(0) && basketBall.GetComponent<Ball>().inHands == true)
        {
            Shot();
        }
        
    }
}
