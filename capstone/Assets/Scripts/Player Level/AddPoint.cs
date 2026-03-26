using System;
using UnityEngine;

public class AddPoint : MonoBehaviour
{
    [SerializeField] levelup levelup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        //Debug.Log(levelup.freePointCount());
        //Debug.Log(gameObject.tag);
        if(levelup.freePointCount() <= 0)
        {
            return;
        }
        if (gameObject.tag == "ATK")
        {
            //Debug.Log("ATK");
            levelup.ATKAdds();
            levelup.useFreePoint();
        }
        else if (gameObject.tag == "DEF")
        {
            //Debug.Log("DEF");
            levelup.DEFAdds();
            levelup.useFreePoint();
        }
        else if (gameObject.tag == "SPD")
        {
            //Debug.Log("SPD");
            levelup.SPDAdds();
            levelup.useFreePoint();
        }
        else if (gameObject.tag == "MAG")
        {
            levelup.MAGAdds();
            levelup.useFreePoint();
        }
    }
}
