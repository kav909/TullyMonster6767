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
        if(levelup.freePointCount() <= 0)
        {
            return;
        }
        if (gameObject.tag == "ATK")
        {
            levelup.ATKAdds();
            levelup.useFreePoint();
        }
        else if (gameObject.tag == "DEF")
        {
            levelup.DEFAdds();
            levelup.useFreePoint();
        }
        else if (gameObject.tag == "SPD")
        {
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
