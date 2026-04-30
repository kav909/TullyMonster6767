using System.Collections.Generic;
using UnityEngine;

public class PriceManager : MonoBehaviour
{
    public List<GameObject> priceList = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addPrice(GameObject a)
    {
        priceList.Add(a);
    }
    public void removePrice()
    {
        for (int i = 0; i < priceList.Count; i++)
        {
            Destroy(priceList[i]);
        }
        priceList.Clear();
    }
}
