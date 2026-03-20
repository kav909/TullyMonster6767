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

    public void play() {

        Debug.Log("play");
        SceneManager.LoadScene(2);

    }

    public void sound() {

        Debug.Log("sound");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Options() {
        Debug.Log("Options");
    }

    public void Back() {
        Debug.Log("back");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
}
