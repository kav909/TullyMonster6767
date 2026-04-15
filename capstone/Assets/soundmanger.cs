using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class soundmanger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioClip[] sfxClips;
    public AudioClip[] musicClips;
    public float masterVol = 0f;
    public float musicVol = 0f;
    public float sfxVol = 0f;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        musicSource = GameObject.Find("music").GetComponent<AudioSource>();
        sfxSource = GameObject.Find("sfx").GetComponent<AudioSource>();
        PlayMusic(0);
        SetMusic(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMaster(float val)
    {
        masterVol = val;
        musicSource.volume = masterVol * musicVol;
        sfxSource.volume = masterVol * sfxVol;
    }

    public void SetMusic(float val)
    {
        musicVol = val;
        musicSource.volume = masterVol * musicVol;
    }

    public void SetSFX(float val)
    {
        sfxVol = val;
        sfxSource.volume = masterVol * sfxVol;
        
    }

    public void PlaySFX(int x) 
    {
        sfxSource.PlayOneShot(sfxClips[x]);
    }

    public void PlayMusic(int x)
    {
        musicSource.clip = musicClips[x];
        musicSource.Play();
    }
}