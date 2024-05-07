using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject storage;
    public GameObject playerCam;
    public GameObject scoreBox;

    private Vector3 storagePos;

    public bool inHands = true;
    public bool scored = false;

    private void Awake()
    {
       //sets physics off 
       this.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void Update()
    {
        Dribble();
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

    }
    
    private void Dribble()
    {
        if (Input.GetKeyUp(KeyCode.Space) && inHands == true)
        {
            StartCoroutine(Bounce());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }


    //switches between physics on and off for a second
    IEnumerator Bounce()
    {
        this.GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(1);
        this.GetComponent<Rigidbody>().isKinematic = true;
        transform.position = storagePos;
    }

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
            scored = true;
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        if (other.gameObject.tag == "deny")
        {
            StartCoroutine(CheatStop());
            Debug.Log("denied");
        }
    }
}
