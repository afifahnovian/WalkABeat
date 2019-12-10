using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaContainer : MonoBehaviour
{
    public Player player;
    public GameObject ManaPrefab;
    public float distanceFromPlayer = 47f;
    public float distanceBetweenSpawns = 96f;

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
            GameObject newObstacle = Instantiate(ManaPrefab);

            newObstacle.transform.position = new Vector3(
                    Random.Range(0f, 1f) > 0.5f ? -1.5f : 1.5f,
                    Random.Range(0f, 0.75f),
                    player.transform.position.z + distanceFromPlayer
                );
            spawnPointer += distanceBetweenSpawns;
        }

    }
}
