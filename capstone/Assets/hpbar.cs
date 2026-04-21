using UnityEngine;
using UnityEngine.UIElements;

public class hpbar : MonoBehaviour
{
    [SerializeField] GameObject hpba;
    public bool cc;
    public int n = 80;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cc) {
            z(n);
                }
        
    }

    private void z(int hp) { 
        
        float i = hp*.01f;
        if (hp == 0)
            i = 0;
       
        hpba.GetComponent<Transform>().localPosition = new Vector3((1f-i)*-.5f, 0, 0);
        hpba.GetComponent<Transform>().localScale = new Vector3(i-.005f, .8f, .9f);
    }
}
