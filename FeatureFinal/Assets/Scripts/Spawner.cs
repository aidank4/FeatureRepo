using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{



    public GameObject player;

    public bool shotBall = false;

    //spawn player and ball to start at random position
    private void Awake()
    {
        SpawnPlayer(player);
    }


    //Spawn player
    public void SpawnPlayer(GameObject newPlayer)
    {
        if(newPlayer = null)
      {
            Destroy(newPlayer);
        }

        newPlayer = player;

        if(newPlayer != null)
       { 
            Vector3 spawnPos;
            spawnPos.z = Random.Range(0, 10);
            spawnPos.x = Random.Range(0, 10);
            spawnPos.y = 0.7f;
            GameObject spawnedPlayer = Instantiate(player, spawnPos, transform.rotation);
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (shotBall == true)
        {
            print("shot yes ty");
            StartCoroutine(Respawn());
            shotBall = false;
        }
    }


    //If player has shot respawn after 5 seconds
    IEnumerator Respawn()
    {
        //Destroy(oldPlayer); oldPlayer = null;
        print("respawning");
        yield return new WaitForSeconds(5);
        SpawnPlayer(player);
    }
}
