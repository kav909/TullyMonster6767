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
        player p = pplayer.GetComponent<player>();

        if (barType == 0)
        {
            float max;
            if (value == 0)
            {
                n = p.hp;
                max = p.maxHp;
            }
            else if (value == 1)
            {
                MonstershootsBlades mob = pplayer.GetComponent<MonstershootsBlades>();
                n = mob.HP;
                max = mob.maxHP;
            }
            else
            {
                monster2script mob = pplayer.GetComponent<monster2script>();
                n = mob.HP;
                max = mob.maxHP;
            }

            if (cc) z(n, max);
        }
        else if (barType == 1)
        {
            n = p.stamina;
            zz(n, p.maxStamina);
            if (p.sprintCooldown)
                gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            else
                gameObject.GetComponent<SpriteRenderer>().color = c;
        }
        else
        {
            n = p.mana;
            zz(n, p.maxMana);
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