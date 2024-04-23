using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject storage;

    private Vector3 storagePos;

    private void Awake()
    {
       //sets physics off 
        Physics.autoSimulation = false;

    }

    private void Update()
    {
        Dribble();
        storagePos = storage.transform.position;
    }
    
    private void Dribble()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            print("dribble");
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
        Physics.autoSimulation = true;
        yield return new WaitForSeconds(1);
        Physics.autoSimulation = false;
        transform.position = storagePos;
    }
}
