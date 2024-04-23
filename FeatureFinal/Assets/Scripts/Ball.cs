using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
   /* private float ballSpeed = 1;

    public bool inHands = true;
    private bool dribbleStart = false;

    private Vector3 startingPos;

    private void Awake()
    {
        startingPos = transform.position;

    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            dribbleStart = true;
            Debug.Log("pressed");
        }
        if (dribbleStart == true)
        {
            Dribble();
            dribbleStart = false;
        }
        
        transform.Translate(Vector3.down * ballSpeed * Time.deltaTime);
    }

    private void Dribble()
    {
        if (inHands)
        {
            transform.Translate(Vector3.down * ballSpeed * Time.deltaTime);
            Debug.Log("Dropping");


        }
        else if (inHands == false)
        {
            Vector3 returning = (startingPos - transform.position).normalized;
            transform.position += returning * ballSpeed * Time.deltaTime;
            Debug.Log("returning");
            inHands = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Floor")
        {
            inHands = false;
            Debug.Log("collided");
        }
    }
*/
}
