using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      //  DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play()
    {
        Debug.Log("play");
        
       SceneManager.LoadScene("Level 1");
        
    }



    public void sound() {

        Debug.Log("sound");
        SceneManager.LoadScene( 1);
    }

    public void Options() {
        Debug.Log("Options");
        SceneManager.LoadScene(2);
    }

    public void Back() {
        Debug.Log("back");
        SceneManager.LoadScene(0);
    }

    public void Test()
    {
        Debug.Log("test");
        SceneManager.LoadScene(6);
    }


}
