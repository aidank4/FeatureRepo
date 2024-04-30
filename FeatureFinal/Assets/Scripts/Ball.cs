using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject storage;

    private Vector3 storagePos;

    public bool inHands = true;

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
}
