using UnityEngine;

public class hpbar : MonoBehaviour
{
    [SerializeField] GameObject hpba;
    [SerializeField] GameObject pplayer;
    public bool cc = true;
    public float n = 0;
    public int value = 0;
    public int barType = 0;
    Color c;

    void Start()
    {
        c = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        GameObject levelupObj = GameObject.Find("levelup");
        levelup stats = null;
        if (levelupObj != null)
            stats = levelupObj.GetComponent<levelup>();

        if (barType == 0) 
        {
            float maxHP = stats != null ? stats.GetMaxHP() : 100f;
            if (value == 0)
                n = pplayer.GetComponent<player>().hp;
            else if (value == 1)
                n = pplayer.GetComponent<MonstershootsBlades>().HP;
            else
                n = pplayer.GetComponent<monster2script>().HP;

            if (cc) 
                z(n, maxHP);
        }
        else if (barType == 1) 
        {
            float maxStamina = stats != null ? stats.GetMaxStamina() : 20f;
            n = pplayer.GetComponent<player>().stamina;
            zz(n, maxStamina);

            if (pplayer.GetComponent<player>().sprintCooldown)
                gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            else
                gameObject.GetComponent<SpriteRenderer>().color = c;
        }
        else 
        {
            float maxMana = stats != null ? stats.GetMaxMana() : 50f;
            n = pplayer.GetComponent<player>().mana;
            zz(n, maxMana);
        }
    }

    private void z(float current, float max)
    {
        float i = max > 0 ? current / max : 0f;
        i = Mathf.Clamp01(i);
        hpba.GetComponent<Transform>().localPosition = new Vector3((1f - i) * -.5f, 0, 0);
        hpba.GetComponent<Transform>().localScale = new Vector3(Mathf.Max(i - .005f, 0f), .8f, .9f);
    }

    private void zz(float current, float max)
    {
        float i = max > 0 ? current / max : 0f;
        i = Mathf.Clamp01(i);
        hpba.GetComponent<Transform>().localPosition = new Vector3(0, (1f - i) * -.5f, 0);
        hpba.GetComponent<Transform>().localScale = new Vector3(.8f, Mathf.Max(i - .005f, 0f), .9f);
    }
}