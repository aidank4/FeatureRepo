using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{



    public GameObject player;
    public GameObject basketball;
    public GameObject basketballStorage;

    public bool shotBall = false;

    private Quaternion startingRot;
   // private Quaternion ballStartingRot;
    private void Awake()
    {
        startingRot = player.transform.rotation;
       // ballStartingRot = basketball.transform.rotation;
    }

    public void LocationSwitch()
    {
        Vector3 spawnPos;
        
        //less chance to spawn farther than the 3 point line
        float randomNum = Random.Range(0, 50);
        if (randomNum < 6)
        {
            spawnPos.z = Random.Range(0, 6);
        }
        else
        {
            spawnPos.z = Random.Range(6, 12);
        }

        spawnPos.x = Random.Range(-6.5f, 6.5f);
        spawnPos.y = 0.7f;

        player.transform.position = spawnPos;
        player.transform.rotation = startingRot;

        basketball.transform.position = basketballStorage.transform.position;
        //basketball.transform.rotation = ballStartingRot;

        basketball.GetComponent<Rigidbody>().isKinematic = true;
        basketball.GetComponent<Ball>().inHands = true;

        //print("swithced spot");

    }
    // Update is called once per frame
    void Update()
    {
        if (shotBall == true)
        {
            //print("shot yes ty");
            StartCoroutine(Respawn());
            shotBall = false;
        }
    }


    //If player has shot respawn after 5 seconds
    IEnumerator Respawn()
    {
        //Destroy(oldPlayer); oldPlayer = null;
       // print("respawning");
        yield return new WaitForSeconds(5);
        LocationSwitch();
        basketball.GetComponent<Ball>().scored = false;
    }
}
