using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBarScript : MonoBehaviour
{
    public Image ManaBar;
    public float MaxMana = 100f;
    public static float mana;
    public float regenSpeed = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        ManaBar = GetComponent<Image>();
        mana = MaxMana;
    }

    // Update is called once per frame
    void Update()
    {
        ManaBar.fillAmount = mana / MaxMana;

        // auto regen mana
        mana += regenSpeed * Time.deltaTime;
    }
}
