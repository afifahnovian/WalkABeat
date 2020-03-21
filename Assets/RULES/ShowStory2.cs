using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStory2 : MonoBehaviour
{
    public GameObject Story2Object;
    public GameObject Story1Object;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void ShowHideStory2()
    {
            Story2Object.SetActive(true);
            Story1Object.SetActive(false);


    }
}
