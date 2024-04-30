using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject player;

    private bool shot = false;

    //spawn player and ball to start at random position
    private void Awake()
    {
        SpawnPlayer();

        shot = player.GetComponent<PlayerShot>().ballShot;
    }


    //Spawn player
    public void SpawnPlayer()
    {
        Vector3 spawnPos;
        spawnPos.z = Random.Range(0 , 10);
        spawnPos.x = Random.Range(0 , 10);
        spawnPos.y = 0.7f;
        GameObject spawnedPlayer = Instantiate(player, spawnPos, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {

        //shot = player.GetComponent<PlayerShot>().ballShot;
        if (shot == true)
        {
            print("shot = true");
            StartCoroutine(Respawn());
            player.GetComponent<PlayerShot>().ballShot = false;
        }
    }

    //If player has shot respawn after 5 seconds
    IEnumerator Respawn()
    {
        print("respawning");
        yield return new WaitForSeconds(2);
        SpawnPlayer();
    }
}
