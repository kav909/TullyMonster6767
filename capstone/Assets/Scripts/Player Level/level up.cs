using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelup : MonoBehaviour
{
    [SerializeField] GameObject ATKAdd;
    [SerializeField] GameObject DEFAdd;
    [SerializeField] GameObject SPDAdd;
    [SerializeField] GameObject MAGAdd;
    [SerializeField] int ATKNum;
    [SerializeField] int DEFNum;
    [SerializeField] int SPDNum;
    [SerializeField] int MAGNum;
    [SerializeField] int FreePointNum;
    [SerializeField] Text ATKText;
    [SerializeField] Text DEFText;
    [SerializeField] Text SPDText;
    [SerializeField] Text MAGText;
    [SerializeField] Text FreePointText;
    public float MaxEXP;
    [SerializeField] GameObject EXPBar;
    [SerializeField] float EXP;
    public static levelup Instance;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persists across unloads
        } 
        else {
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)   ////<<--- 
    {

        ATKAdd = GameObject.FindGameObjectWithTag("ATK");
        DEFAdd = GameObject.FindGameObjectWithTag("DEF");
        SPDAdd = GameObject.FindGameObjectWithTag("SPD");
        MAGAdd = GameObject.FindGameObjectWithTag("MAG");
        ATKText = GameObject.Find("ATK").GetComponent<Text>();
        DEFText = GameObject.Find("DEF").GetComponent<Text>();
        SPDText = GameObject.Find("SPD").GetComponent<Text>();
        MAGText = GameObject.Find("MAG").GetComponent<Text>();
        FreePointText = GameObject.Find("Free Point").GetComponent<Text>();
        EXPBar = GameObject.FindGameObjectWithTag("EXPBar");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /* ATKNum = 5;
         DEFNum = 5;
         SPDNum = 5;
         MAGNum = 5;
         FreePointNum = 5;*/
        //EXPBar.transform.position += Vector3.left * 80f;
    }

    // Update is called once per frame
    void Update()
    {
        float EXPPercent = (EXP/MaxEXP);
        Vector3 currentScale = EXPBar.transform.localScale;
        currentScale.x = 3.5f * EXPPercent;
        EXPBar.transform.localScale = currentScale;
        EXPBar.transform.position = Vector3.left * (-3.5f * (EXPPercent / 2f) + 8.5f) + Vector3.up * 4.4f;
        ATKText.text = "" + ATKNum;
        DEFText.text = "" + DEFNum;
        SPDText.text = "" + SPDNum;
        MAGText.text = "" + MAGNum;
        FreePointText.text = "" + FreePointNum;
    }
    public void ATKAdds()
    {
        ATKNum++;
    }
    public void DEFAdds()
    {
        DEFNum++;
    }
    public void SPDAdds()
    {
        SPDNum++;
    }
    public void MAGAdds()
    {
        MAGNum++;
    }
    public void useFreePoint()
    {
        FreePointNum--;
    }
    public int freePointCount()
    {
        return FreePointNum;
    }
    public void equipATK(int point)
    {
        ATKNum += point;
    }
    public void equipDEF(int point)
    {
        DEFNum += point;
    }
    public void equipSPD(int point)
    {
        SPDNum += point;
    }
    public void equipMAG(int point)
    {
        MAGNum += point;
    }
    public void unequipATK(int point)
    {
        ATKNum -= point;
    }
    public void unequipDEF(int point)
    {
        DEFNum -= point;
    }
    public void unequipSPD(int point)
    {
        SPDNum -= point;
    }
    public void unequipMAG(int point)
    {
        MAGNum -= point;
    }
}
