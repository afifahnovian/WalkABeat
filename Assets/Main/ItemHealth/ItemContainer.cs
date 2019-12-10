using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    public Player player;
    public GameObject itemPrefab;
    public float distanceFromPlayer = 1f;
    public float distanceBetweenSpawns = 66f;

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
            GameObject newObstacle = Instantiate(itemPrefab);

            newObstacle.transform.position = new Vector3(
                    Random.Range(0f, 1f) > 0.5f ? -1.5f : 1.5f,
                    Random.Range(0f, 0.75f),
                    player.transform.position.z + distanceFromPlayer
                );
            spawnPointer += distanceBetweenSpawns;
        }

    }
}
