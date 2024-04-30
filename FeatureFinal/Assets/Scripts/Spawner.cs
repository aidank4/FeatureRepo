using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject player;

    //spawn player and ball to start at random position
    private void Awake()
    {
        SpawnPlayer();
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
        /*if (GameObject.Find("Player").GetComponent<PlayerShot>().ballShot == true)
        {
            print("shot = true");
            StartCoroutine(Respawn());
        }*/
    }

    //If player has shot respawn after 5 seconds
    IEnumerator Respawn()
    {
        print("respawning");
        yield return new WaitForSeconds(5);
        SpawnPlayer();
    }
}
