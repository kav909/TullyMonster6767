using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PriceManager : MonoBehaviour
{
    public bool isRefresh;
    public List<GameObject> priceList = new List<GameObject>();
    public static PriceManager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            //Destroy(gameObject); // destroy duplicate
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

       
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
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
    public void isBought(int index, int adjustIndex)
    {
        Debug.Log("index - adjustIndex is: " + (index - adjustIndex));
        Debug.Log("index is: " + index);
        Debug.Log("adjustIndex is: " + adjustIndex);
        if (isRefresh)
        {
            Destroy(priceList[index - adjustIndex]);
            priceList.RemoveAt(index - adjustIndex);
        }
        else
        {
            Destroy(priceList[index - adjustIndex]);
            priceList.RemoveAt(index - adjustIndex);
        }
        isRefresh = false;


    }
}
