using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Kelly, Aidan
/// 05/08/2024
/// Controls ball events
/// </summary>

public class Ball : MonoBehaviour
{
    public GameObject storage;
    public GameObject playerCam;
    public GameObject scoreBox;

    private Vector3 storagePos;

    public bool inHands = true;

    public int score = 0;
    public int shotsTaken = 0;

    private void Awake()
    {
       //sets physics off 
       this.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void Update()
    {
        storagePos = storage.transform.position;

        if (inHands == false)
        {
            transform.parent = null;
        }
        if (inHands == true)
        {
            this.gameObject.transform.parent = playerCam.transform;
            //print("childed");
        }

        //win check
        if (score >= 10)
        {
            Debug.Log("You Win");
            SceneManager.LoadScene(3);
        }

    }
    
    //will come back to the dribllein the future!
    /*private void Dribble()
    {
        if (Input.GetKeyUp(KeyCode.Space) && inHands == true)
        {
            StartCoroutine(Bounce());
        }
    }
    */

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }
   

    //will come back
    //switches between physics on and off for a second
    /*
    IEnumerator Bounce()
    {
        this.GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(1);
        this.GetComponent<Rigidbody>().isKinematic = true;
        transform.position = storagePos;
    }
    */

    /// <summary>
    /// Turns off the score collider for a brief second to deny double shots and under the hoop shots
    /// </summary>
    /// <returns></returns>
    IEnumerator CheatStop()
    {
        scoreBox.gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        scoreBox.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "score")
        {
            Debug.Log("SCORE!!");
            score += 1;
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            StartCoroutine(CheatStop());
        }
        if (other.gameObject.tag == "deny")
        {
            StartCoroutine(CheatStop());
            Debug.Log("denied");
        }
    }
}
