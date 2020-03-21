using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerToStoryScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void StoryScene()
    {
        SceneManager.LoadScene("StoryScene");
    }


}
