using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Kelly, Aidan
/// 05/08/2024
/// Controls player spawn placement between shots
/// </summary>

public class Spawner : MonoBehaviour
{
    public GameObject player;
    public GameObject basketball;
    public GameObject basketballStorage;

    public bool shotBall = false;
    private bool respawning = false;
    private bool isRunning = false;

    private Quaternion startingRot;
    private void Awake()
    {
        startingRot = player.transform.rotation;
    }

    /// <summary>
    /// sets a random location within the court for the player to spawn. higher chance of spawning closer to the basket
    /// </summary>
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

        spawnPos.x = Random.Range(-7.5f, 7.5f);
        spawnPos.y = 0.7f;

        player.transform.position = spawnPos;
        player.transform.rotation = startingRot;

        basketball.transform.position = basketballStorage.transform.position;
        //basketball.transform.rotation = ballStartingRot;

        basketball.GetComponent<Rigidbody>().isKinematic = true;
        basketball.GetComponent<Ball>().inHands = true;

    }
    // Update is called once per frame
    void Update()
    {
        if (shotBall == true && isRunning == false)
        {
            StartCoroutine(Respawn());
            shotBall = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            
            shotBall = false;
            respawning = true;
            LocationSwitch();
        }
    }

    //If player has shot respawn after 5 seconds
    IEnumerator Respawn()
    {
        isRunning = true;
        if (respawning == true)
        {
            respawning = false;
        }
        yield return new WaitForSeconds(5);
        if (respawning == true)
        {
            respawning = false;
            StopCoroutine(Respawn());
        }
        else
        {
            respawning = false;
            LocationSwitch();
        }
        isRunning = false;
    }
}
