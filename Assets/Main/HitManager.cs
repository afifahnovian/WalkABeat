using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    public static float speed = 4.0f;
    public float swordRange = 1.75f;
    public Player player;
    public TextMesh infoText;
    public float TextTime = 5f;
    public float jumpHeight = 1.7f;
    public float walkingAmplitude = 0.25f;
    public float walkingFrequency = 2.0f;
    Color32 merah = new Color32(237, 157, 163, 255);
    public bool isDead = false;
    private Vector3 swordTargetPosition;
    private Vector3 swordBeginPosition;
    public GameObject sword;
    private bool isSlashed = false;
    private bool isAppear = false;
    private float timeWhenDisappear;
    private float timeToAppear = 2f;

    // Start is called before the first frame update
    void Start()
    {
        swordTargetPosition = sword.transform.localPosition;
        swordBeginPosition = sword.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //code for moving player to direction it facing 
        player.transform.position += transform.forward * speed * Time.deltaTime;

        //code for give player sense of walking
        player.transform.position = new Vector3(
            player.transform.position.x,
            jumpHeight + Mathf.Cos(player.transform.position.z * walkingFrequency) * walkingAmplitude,
            player.transform.position.z
        );

        //constraint x
        if (player.transform.position.x < -4.0f)
        {
            player.transform.position = new Vector3(-4.0f, player.transform.position.y, player.transform.position.z);
        }
        else if (player.transform.position.x > 4.0f)
        {
            player.transform.position = new Vector3(4.0f, player.transform.position.y, player.transform.position.z);
        }

        //code for arranging the speed based of the distance the player already taken
        if (player.transform.position.z >= 200 & player.transform.position.z <= 400)
        {
            speed = 5.0f;
        }
        else if (player.transform.position.z > 400 & player.transform.position.z >= 600)
        {
            speed = 6.0f;
        }
        else if (player.transform.position.z > 800)
        {
            speed = 7.0f;
        }

        if (player.isDead || player.isCrossingFinishLine)
        {
            return;
        }

        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("space"))
        {
            RaycastHit hit;

            //hit enemy
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.transform.GetComponent<Enemy>() != null || hit.transform.GetComponent<HealthPotion>() != null || hit.transform.GetComponent<ManaPotion>() != null)
                {

                    // set disappear time for text
                    timeWhenDisappear = Time.time + timeToAppear;
                    isAppear = true;

                    if (isSlashed)
                    {
                        swordTargetPosition = swordBeginPosition;
                    }
                    else
                    {
                        swordTargetPosition = new Vector3(-6, swordTargetPosition.y, swordTargetPosition.z);
                    }
                    isSlashed = !isSlashed;

                    if (hit.transform.GetComponent<Enemy>() != null && hit.transform.position.z - this.transform.position.z < swordRange)
                    {
                        if (ManaBarScript.mana > 0)
                        {
                            ManaBarScript.mana -= 10;
                            Player.score += 10;
                            Destroy(hit.transform.gameObject);
                            infoText.color = Color.green;
                            infoText.text = "Score +10";
                            Debug.Log("Pukul " + hit.transform.name);
                        }
                        else if (ManaBarScript.mana <= 0)
                        {
                            HealthBarScript.health -= 10f;
                            if (HealthBarScript.health <= 0)
                            {
                                isDead = true;
                            }

                            infoText.color = merah;
                            infoText.text = "Health -10";

                        }
                    }

                    //hit item health
                    else if (hit.transform.GetComponent<HealthPotion>() != null && hit.transform.position.z - this.transform.position.z < swordRange + 5.0f)
                    {
                        Destroy(hit.transform.gameObject);
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
                        TextTime -= TextTime - 1f;
                    }

                    //hit  mana
                    else if (hit.transform.GetComponent<ManaPotion>() != null && hit.transform.position.z - this.transform.position.z < swordRange + 5.0f)
                    {
                        Destroy(hit.transform.gameObject);
                        ManaBarScript.mana += 10f;
                        if (ManaBarScript.mana >= 100)
                        {
                            ManaBarScript.mana = 100;
                        }

                        infoText.color = Color.green;
                        infoText.text = "Mana +10";
                        TextTime -= TextTime - 1f;
                    }
                }
            }
        }

        if (isAppear && (Time.time >= timeWhenDisappear))
        {
            infoText.text = "";
            isAppear = false;
        }

        //Linear interpolation from sword beginning position to sword target position, move slowly
        sword.transform.localPosition = Vector3.Lerp(sword.transform.localPosition, swordTargetPosition, Time.deltaTime * 5f);
    }
}