using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerToMainScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void MainScene()
    {
        SceneManager.LoadScene("MainScene");
        HitManager.speed = 4.0f;
        Player.score = 0;
    }


}
