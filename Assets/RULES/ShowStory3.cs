using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStory3 : MonoBehaviour
{
    public GameObject Story2Object;
    public GameObject Story1Object;
    public GameObject Story3Object;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowHideStory3()
    {
        Story3Object.SetActive(true);
        Story2Object.SetActive(false);
        Story1Object.SetActive(false);


    }
}
