using UnityEngine;

public class soundmanger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioSource musicSource;
    public AudioSource sfxSource;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        musicSource = GameObject.Find("music").GetComponent<AudioSource>();
        sfxSource = GameObject.Find("sfx").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMaster(float x)
    {
        musicSource.volume = x;
        sfxSource.volume = x;
    }

    public void SetMusic(float x) { 
        musicSource.volume = x; 
    }
    public void SetSFX(float x) {
        sfxSource.volume = x; 
    }
    
    public void PlaySFX(AudioClip clip) 
    { 
        sfxSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip) {
        musicSource.clip = clip; musicSource.Play(); 
    }
}