using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isAppear = false;
    private float timeWhenDisappear;
    private float timeToAppear = 2f;
    public bool isDead = false;
    public bool isCrossingFinishLine = false;
    public TextMesh scoreText;
    public TextMesh infoText;
    Color32 merah = new Color32(237, 157, 163, 255);
    public static int score = 0;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (isDead || isCrossingFinishLine)
        {
            return;
        }
        scoreText.text = "Score : " + score;

        if (isAppear && (Time.time >= timeWhenDisappear))
        {
            infoText.text = "";
            isAppear = false;
        }
    }


    void OnTriggerEnter(Collider collider)
    {
        // set disappear time for text
        timeWhenDisappear = Time.time + timeToAppear;
        isAppear = true;

        if (collider.GetComponent<Enemy>() != null)
        {
            HealthBarScript.health -= 10f;
            Destroy(collider.gameObject);
            if (HealthBarScript.health <= 0)
            {
                isDead = true;
            }
            Debug.Log("Nabrak " + collider.name);


            infoText.color = merah;
            infoText.text = "Health -10";
        }
        else if (collider.GetComponent<HealthPotion>() != null)
        {

            Destroy(collider.gameObject);
            if (HealthBarScript.health >= 100)
            {
                HealthBarScript.health = 100;
            }
            else
            {
                HealthBarScript.health += 10f;
            }

            infoText.color = Color.green;
            infoText.text = "Health +10";
        }
        else if (collider.GetComponent<ManaPotion>() != null)
        {
            Destroy(collider.gameObject);
            ManaBarScript.mana += 10f;
            if (ManaBarScript.mana >= 100)
            {
                ManaBarScript.mana = 100;
            }

            infoText.color = Color.green;
            infoText.text = "Mana +10";
        }
        else if (collider.tag == "FinishLine")
        {
            isCrossingFinishLine = true;
        }
    }
}
