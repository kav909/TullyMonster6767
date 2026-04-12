using TMPro;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CameraMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] UnityEngine.Transform target;
    float chachUpTime = .55f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] float leftB;
    [SerializeField] float rightB;
    [SerializeField] float upB;
    [SerializeField] float bottomB;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void Start()
    {
        leftB = transform.position.x - 1.5f;
        rightB = transform.position.x + 1.5f;
        upB = transform.position.y + 0.5f;
        bottomB = transform.position.y - 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

        if (target.position.x <= leftB || target.position.x >= rightB || target.position.y >= upB || target.position.y <= bottomB)
        {
            //   Debug.Log("Camera Move");
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, chachUpTime);
            leftB = transform.position.x - 0f;
            rightB = transform.position.x + 0f;
            upB = transform.position.y + 0f;
            bottomB = transform.position.y - 0f;
        }

        //Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        // transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, chachUpTime);
    }
    public void SetTransformTarget(UnityEngine.Transform newTarget)
    {
        target = newTarget;
    }

}
