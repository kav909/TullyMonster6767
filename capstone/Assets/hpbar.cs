using UnityEngine;
using UnityEngine.UIElements;

public class hpbar : MonoBehaviour
{
    [SerializeField] GameObject hpba;
    [SerializeField] GameObject pplayer;
    public bool cc = true;
    public float n = 90;
    public int value = 0;
    public int barType = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (barType == 0)
        {


            if (value == 0)
            {
                n = pplayer.GetComponent<player>().hp;
            }
            else if (value == 1)
            {
                n = pplayer.GetComponent<MonstershootsBlades>().HP;
            }
            else
            {
                n = pplayer.GetComponent<monster2script>().HP;
            }

            if (cc)
            {
                z(n);
            }
        }
        else if (barType == 1)
        {
            n = pplayer.GetComponent<player>().stamina;
            zz(n);
        }
        else {
            n = pplayer.GetComponent<player>().mana;
            zz(n);
        }
    }

    private void z(float hp) { 
       // n= hp;
        float i = hp*.01f;
        if (hp == 0)
            i = 0;
       
        hpba.GetComponent<Transform>().localPosition = new Vector3((1f-i)*-.5f, 0, 0);
        hpba.GetComponent<Transform>().localScale = new Vector3(i-.005f, .8f, .9f);
    }

    private void zz(float st)
    {
        // n= hp;
        float i = st * .01f;
        if (st == 0)
            i = 0;

        hpba.GetComponent<Transform>().localPosition = new Vector3(0,(1f - i) * -.5f, 0);
        hpba.GetComponent<Transform>().localScale = new Vector3(.8f, i - .005f, .9f);
    }
}
