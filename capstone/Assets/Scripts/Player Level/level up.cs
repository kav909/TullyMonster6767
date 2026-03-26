using UnityEngine;
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ATKNum = 1;
        DEFNum = 1;
        SPDNum = 1;
        MAGNum = 1;
        FreePointNum = 5;
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
}
