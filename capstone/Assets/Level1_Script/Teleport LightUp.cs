using System.Drawing;
using UnityEngine;

public class TeleportLightUp : MonoBehaviour
{
    [SerializeField] GameObject Light1;
    [SerializeField] GameObject Light2;
    [SerializeField] GameObject Light3;
    [SerializeField] GameObject Light4;
    [SerializeField] int LightSpeed;
    public float TargetShade;
    private SpriteRenderer sr1;
    private SpriteRenderer sr2;
    private SpriteRenderer sr3;
    private SpriteRenderer sr4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LightSpeed = 1;
        sr1 = Light1.GetComponent<SpriteRenderer>();
        sr2 = Light2.GetComponent<SpriteRenderer>();
        sr3 = Light3.GetComponent<SpriteRenderer>();
        sr4 = Light4.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Color color = sr1.color;
        color.a = Mathf.MoveTowards(color.a, TargetShade, LightSpeed * Time.deltaTime);
        sr1.color = color;
        sr2.color = color;
        sr3.color = color;
        sr4.color = color;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TargetShade = 1f;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        TargetShade = 0f;
    }
    public void setOpacity(float opacity)
    {
        UnityEngine.Color color = sr1.color;
        color.a = opacity;
        sr1.color = color;

        color.a = opacity;
        sr2.color = color;

        color.a = opacity;
        sr3.color = color;

        color.a = opacity;
        sr4.color = color;
    }
}
