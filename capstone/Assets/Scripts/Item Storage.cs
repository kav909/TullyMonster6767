using Unity.VisualScripting;
using UnityEngine;

public class ItemStorage : MonoBehaviour
{
    
    [SerializeField] GameObject sword;
    [SerializeField] GameObject Bow;
    [SerializeField] GameObject GreatAxe;
    [SerializeField] GameObject Mace;
    [SerializeField] GameObject Shield;
    [SerializeField] GameObject Axe;
    [SerializeField] GameObject PriestStaff;
    [SerializeField] GameObject MageStaff;
    [SerializeField] GameObject LongSword;
     
    [SerializeField] GameObject cloth1;
    [SerializeField] GameObject cloth2;
    [SerializeField] GameObject cloth3;
    [SerializeField] GameObject Front1;
    [SerializeField] GameObject Front2;
    [SerializeField] GameObject Front3;
    [SerializeField] GameObject Front4;
    [SerializeField] GameObject Head1;
    [SerializeField] GameObject Head2;
    [SerializeField] GameObject Head3;
    [SerializeField] GameObject glove1;
    [SerializeField] GameObject glove2;
    [SerializeField] GameObject glove3;
    [SerializeField] GameObject Shoe1;
    [SerializeField] GameObject Shoe2;
    [SerializeField] GameObject Shoe3;
    [SerializeField] GameObject Pants1;
    [SerializeField] GameObject Pants2;
    [SerializeField] GameObject Pants3;
    [SerializeField] GameObject Elit_cloth1;
    [SerializeField] GameObject Elit_cloth2;
    [SerializeField] GameObject Elit_cloth3;
    [SerializeField] GameObject Elit_Front1;
    [SerializeField] GameObject Elit_Front2;
    [SerializeField] GameObject Elit_Front3;
    [SerializeField] GameObject Elit_Front4;
    [SerializeField] GameObject Elit_Head1;
    [SerializeField] GameObject Elit_Head2;
    [SerializeField] GameObject Elit_Head3;
    [SerializeField] GameObject Elit_glove1;
    [SerializeField] GameObject Elit_glove2;
    [SerializeField] GameObject Elit_glove3;
    [SerializeField] GameObject Elit_Shoe1;
    [SerializeField] GameObject Elit_Shoe2;
    [SerializeField] GameObject Elit_Shoe3;
    [SerializeField] GameObject Elit_Pants1;
    [SerializeField] GameObject Elit_Pants2;
    [SerializeField] GameObject Elit_Pants3;

    GameObject[] HeadSlot = new GameObject[6];
    GameObject[] FrontSlot = new GameObject[8];
    GameObject[] BodySlot = new GameObject[6];
    GameObject[] PantsSlot = new GameObject[6];
    GameObject[] GloveSlot = new GameObject[6];
    GameObject[] ShoeSlot = new GameObject[6];
    GameObject[] WeaponSlot = new GameObject[9];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HeadSlot = GameObject.FindGameObjectsWithTag("Head");
        FrontSlot = GameObject.FindGameObjectsWithTag("Front");
        BodySlot = GameObject.FindGameObjectsWithTag("Body");
        PantsSlot = GameObject.FindGameObjectsWithTag("Pants");
        GloveSlot = GameObject.FindGameObjectsWithTag("Glove");
        ShoeSlot = GameObject.FindGameObjectsWithTag("Shoe");
        WeaponSlot = GameObject.FindGameObjectsWithTag("Weapon");
        //Debug.Log(HeadSlot.Length);
        //Debug.Log(FrontSlot.Length);
        //Debug.Log(BodySlot.Length);
        //Debug.Log(PantsSlot.Length);
        //Debug.Log(GloveSlot.Length);
        //Debug.Log(ShoeSlot.Length);
        //Debug.Log(WeaponSlot.Length);
       // Debug.Log(WeaponSlot.);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public GameObject[] getHeadSlot()
    {
        return HeadSlot;
    }
    public GameObject[] getFrontSlot()
    {
        return FrontSlot; 
    }
    public GameObject[] getBodySlot()
    {
        return BodySlot;
    }
    public GameObject[] getPantsSlot()
    {
        return PantsSlot;
    }
    public GameObject[] getGloveSlot()
    {
        return GloveSlot;
    }
    public GameObject[] getShoeSlot()
    {
        return ShoeSlot;
    }
    public GameObject[] getWeaponSlot()
    {
        return WeaponSlot;
    }
}

