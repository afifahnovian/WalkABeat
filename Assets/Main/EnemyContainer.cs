using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContainer : MonoBehaviour
{
    public Player player;
    public GameObject enemyPrefab;
    public float distanceFromPlayer = 35f;
    public float distanceBetweenSpawns = 15f;

    private float spawnPointer = 0f;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (spawnPointer < player.transform.position.z)
        {
            GameObject newObstacle = Instantiate(enemyPrefab);

            newObstacle.transform.position = new Vector3(
                    Random.Range(0f, 1f) > 0.5f ? -4.5f : 4.5f,
                    -0.5f,
                    player.transform.position.z + distanceFromPlayer
                );
            spawnPointer += distanceBetweenSpawns;
        }


    }
}
