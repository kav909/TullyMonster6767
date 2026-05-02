using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class iconsattack : MonoBehaviour
{
    public int attackType = 0;

    GameObject playerObj;
    SpriteRenderer icon;
    public Text timerText; 

    Color activeColor;
    Color cooldownColor = new Color(0.3f, 0.3f, 0.3f, 1f);

    void Start()
    {
       
        icon = GetComponent<SpriteRenderer>();

        activeColor = icon.color;

        if (playerObj == null)
            playerObj = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        float cooldown = 0f;

        if (attackType == 0)
            cooldown = playerObj.GetComponent<player>().cooldownArrow;
        else if (attackType == 1)
            cooldown = playerObj.GetComponent<player>().cooldownPunch;
        else
            cooldown = playerObj.GetComponent<player>().cooldownWolf;

        bool onCooldown = cooldown > 0f;
        icon.color = onCooldown ? cooldownColor : activeColor;

        if (onCooldown)
            timerText.text = cooldown.ToString("F1");
        else
            timerText.text = "";
    }
}