using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneryManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] sceneries;
    public float offsetLength = 40f;
    public float playerDistance = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject scenery in sceneries)
        {
            if(player.transform.position.z - scenery.transform.position.z > playerDistance)
            {
                scenery.transform.position += new Vector3(scenery.transform.position.x, scenery.transform.localPosition.y, offsetLength * sceneries.Length);
            }
        }
    }
}
