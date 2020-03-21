using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TextMesh infoText;
    public GameObject gameOver;
    public GameObject finishGate;
    public Player player;
    private float restartTimer = 3f;
    public bool isRestart = false;
    Color32 kuning = new Color32(214, 210, 139, 255);
    public float finishGateDistance = 200f;

    // Start is called before the first frame update
    void Start()
    {
        infoText.text = "Start Game";
        finishGate.transform.position = new Vector3(
            finishGate.transform.position.x,
            finishGate.transform.position.y,
            finishGateDistance
            );
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isCrossingFinishLine)
        {
            infoText.color = Color.green;
            infoText.text = "You Win !";
            gameOver.SetActive(true);
            HitManager.speed = 0.0f;
        }
        else if (player.isDead)
        {
            infoText.color = kuning;
            infoText.text = "Game Over !";
            gameOver.SetActive(true);
            HitManager.speed = 0.0f;

            restartTimer -= Time.deltaTime;
            if (restartTimer <= 0f)
            {    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                HitManager.speed = 4.0f;
                Player.score = 0;
            }
            
        }


    }
}
