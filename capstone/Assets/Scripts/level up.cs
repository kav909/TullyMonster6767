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
    public int MaxEXP;
    [SerializeField] int EXP;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ATKNum = 5;
        DEFNum = 5;
        SPDNum = 5;
        MAGNum = 5;
        FreePointNum = 5;
    }

    // Update is called once per frame
    void Update()
    {
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
