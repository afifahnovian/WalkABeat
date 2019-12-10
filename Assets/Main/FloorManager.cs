using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] floors;
    public float offsetLength = 40f;
    public float playerDistance = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject floor in floors)
        {
            if(player.transform.position.z - floor.transform.position.z > playerDistance)
            {
                floor.transform.position += new Vector3(0, 0, offsetLength * floors.Length);
            }
        }
    }
}
