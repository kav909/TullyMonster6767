using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuyEquipment : MonoBehaviour
{
    [SerializeField] Equip Equip;
    [SerializeField] PriceManager manager;
    [SerializeField] ItemStorage itemStorage;
    [SerializeField] Shopplace Shopplace;
    public static BuyEquipment Instance;
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
        manager = GameObject.Find("PriceManager").GetComponent<PriceManager>();
        Shopplace = GameObject.Find("weapon shop").GetComponent<Shopplace>();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.Find("PriceManager").GetComponent<PriceManager>();
        Shopplace = GameObject.Find("weapon shop").GetComponent<Shopplace>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        int numOfNull = 0;
        for (int i = 0; i < manager.priceList.Count; i++)
        {
            if (manager.priceList[i] == null)
            {
                numOfNull++;
                Debug.Log("AAAAAAAAA" + numOfNull);
            }
            if (manager.priceList[i] == gameObject)
            {
                break;
            }
        }
        //manager.isRefresh = false;
        Debug.Log("Buy Weapon");
        if (gameObject.tag == "Weapon")
        {
            int numOfNullinArray = 0;
            Debug.Log(itemStorage.WeaponSlot);
            for (int i = 0; i < itemStorage.WeaponSlot.Length; i++)
            {
                if (itemStorage.WeaponSlot[i] == null)
                {
                    numOfNullinArray++;
                    Debug.Log("AAAAAAAAA" + numOfNullinArray);
                }
                if (itemStorage.WeaponSlot[i] == gameObject)
                {
                    break;
                }
            }
            Debug.Log("The number of null there is is: " + numOfNullinArray);
            int x = Equip.findOpenWeaponIndex();
            Debug.Log("The index where the equipment is in the array: "+Array.IndexOf(itemStorage.WeaponSlot, gameObject));
            Equip.WeaponItem[Equip.findOpenWeaponIndex()] = gameObject;
            manager.isBought(Array.IndexOf(itemStorage.WeaponSlot, gameObject), numOfNullinArray);
            gameObject.transform.position = new Vector2(0f, -80f);
            itemStorage.WeaponSlot[Array.IndexOf(itemStorage.WeaponSlot, gameObject)] = null;
        }
        if (gameObject.tag == "Head")
        {
            int numOfNullinArray = 0;
            Debug.Log(itemStorage.HeadSlot);
            for (int i = 0; i < itemStorage.HeadSlot.Length; i++)
            {
                if (itemStorage.HeadSlot[i] == null)
                {
                    numOfNullinArray++;
                    Debug.Log("AAAAAAAAA" + numOfNullinArray);
                }
                if (itemStorage.HeadSlot[i] == gameObject)
                {
                    break;
                }
            }
            Debug.Log("The number of null there is is: " + numOfNull);
            int x = Equip.findOpenHeadIndex();
            Debug.Log(Array.IndexOf(itemStorage.HeadSlot, gameObject));
            Equip.HeadItem[Equip.findOpenHeadIndex()] = gameObject;
            manager.isBought(Array.IndexOf(itemStorage.HeadSlot, gameObject), numOfNullinArray);
            gameObject.transform.position = new Vector2(0f, -80f);
            itemStorage.HeadSlot[Array.IndexOf(itemStorage.HeadSlot, gameObject)] = null;
        }
        if (gameObject.tag == "Front")
        {
            int numOfNullinArray = 0;
            Debug.Log(itemStorage.FrontSlot);
            for (int i = 0; i < itemStorage.FrontSlot.Length; i++)
            {
                if (itemStorage.FrontSlot[i] == null)
                {
                    numOfNullinArray++;
                    Debug.Log("AAAAAAAAA" + numOfNullinArray);
                }
                if (itemStorage.FrontSlot[i] == gameObject)
                {
                    break;
                }
            }
            Debug.Log("The number of null there is is: " + numOfNull);
            int x = Equip.findOpenFrontIndex();
            Debug.Log(Array.IndexOf(itemStorage.FrontSlot, gameObject));
            Equip.FrontItem[Equip.findOpenFrontIndex()] = gameObject;
            manager.isBought(Array.IndexOf(itemStorage.FrontSlot, gameObject), numOfNullinArray);
            gameObject.transform.position = new Vector2(0f, -80f);
            itemStorage.FrontSlot[Array.IndexOf(itemStorage.FrontSlot, gameObject)] = null;
        }
        if (gameObject.tag == "Body")
        {
            int numOfNullinArray = 0;
            Debug.Log(itemStorage.BodySlot);
            for (int i = 0; i < itemStorage.BodySlot.Length; i++)
            {
                if (itemStorage.BodySlot[i] == null)
                {
                    numOfNullinArray++;
                    Debug.Log("AAAAAAAAA" + numOfNullinArray);
                }
                if (itemStorage.BodySlot[i] == gameObject)
                {
                    break;
                }
            }
            Debug.Log("The number of null there is is: " + numOfNull);
            int x = Equip.findOpenBodyIndex();
            Debug.Log(Array.IndexOf(itemStorage.BodySlot, gameObject));
            Equip.BodyItem[Equip.findOpenBodyIndex()] = gameObject;
            manager.isBought(Array.IndexOf(itemStorage.BodySlot, gameObject), numOfNullinArray);
            gameObject.transform.position = new Vector2(0f, -80f);
            itemStorage.BodySlot[Array.IndexOf(itemStorage.BodySlot, gameObject)] = null;
        }
        if (gameObject.tag == "Pants")
        {
            int numOfNullinArray = 0;
            Debug.Log(itemStorage.PantsSlot);
            for (int i = 0; i < itemStorage.PantsSlot.Length; i++)
            {
                if (itemStorage.PantsSlot[i] == null)
                {
                    numOfNullinArray++;
                    Debug.Log("AAAAAAAAA" + numOfNullinArray);
                }
                if (itemStorage.PantsSlot[i] == gameObject)
                {
                    break;
                }
            }
            Debug.Log("The number of null there is is: " + numOfNull);
            int x = Equip.findOpenPantsIndex();
            Debug.Log(Array.IndexOf(itemStorage.PantsSlot, gameObject));
            Equip.PantsItem[Equip.findOpenPantsIndex()] = gameObject;
            manager.isBought(Array.IndexOf(itemStorage.PantsSlot, gameObject), numOfNullinArray);
            gameObject.transform.position = new Vector2(0f, -80f);
            itemStorage.PantsSlot[Array.IndexOf(itemStorage.PantsSlot, gameObject)] = null;
        }
        if (gameObject.tag == "Glove")
        {
            int numOfNullinArray = 0;
            Debug.Log(itemStorage.GloveSlot);
            for (int i = 0; i < itemStorage.GloveSlot.Length; i++)
            {
                if (itemStorage.GloveSlot[i] == null)
                {
                    numOfNullinArray++;
                    Debug.Log("AAAAAAAAA" + numOfNullinArray);
                }
                if (itemStorage.GloveSlot[i] == gameObject)
                {
                    break;
                }
            }
            Debug.Log("The number of null there is is: " + numOfNull);
            int x = Equip.findOpenGloveIndex();
            Debug.Log(Array.IndexOf(itemStorage.GloveSlot, gameObject));
            Equip.GloveItem[Equip.findOpenGloveIndex()] = gameObject;
            manager.isBought(Array.IndexOf(itemStorage.GloveSlot, gameObject), numOfNullinArray);
            gameObject.transform.position = new Vector2(0f, -80f);
            itemStorage.GloveSlot[Array.IndexOf(itemStorage.GloveSlot, gameObject)] = null;
        }
        if (gameObject.tag == "Shoe")
        {
            int numOfNullinArray = 0;
            Debug.Log(itemStorage.ShoeSlot);
            for (int i = 0; i < itemStorage.ShoeSlot.Length; i++)
            {
                if (itemStorage.ShoeSlot[i] == null)
                {
                    numOfNullinArray++;
                    Debug.Log("AAAAAAAAA" + numOfNullinArray);
                }
                if (itemStorage.ShoeSlot[i] == gameObject)
                {
                    break;
                }
            }
            Debug.Log("The number of null there is is: " + numOfNull);
            int x = Equip.findOpenShoeIndex();
            Debug.Log(Array.IndexOf(itemStorage.ShoeSlot, gameObject));
            Equip.ShoeItem[Equip.findOpenShoeIndex()] = gameObject;
            manager.isBought(Array.IndexOf(itemStorage.ShoeSlot, gameObject), numOfNullinArray);
            gameObject.transform.position = new Vector2(0f, -80f);
            itemStorage.ShoeSlot[Array.IndexOf(itemStorage.ShoeSlot, gameObject)] = null;
        }

    }
}
