using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip[] clips;
    private AudioSource audioSource;

    public Slider volumeSlider;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        

        
        InitializeVolumeSlider();

        PlayAudioForScene(SceneManager.GetActiveScene().name);
    }

    void OnEnable()
    {
        
        InitializeVolumeSlider();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void InitializeVolumeSlider()
    {
        if (volumeSlider == null)
        {
            volumeSlider = GameObject.FindGameObjectWithTag("VolumeSlider")?.GetComponent<Slider>();
        }

        if (volumeSlider != null)
        {
            volumeSlider.value = audioSource.volume;
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged); 
        }
        else
        {
            Debug.LogWarning("Volume Slider is missing! Please assign a Slider in the Inspector.");
        }

    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StopClip();
        PlayAudioForScene(scene.name);

        InitializeVolumeSlider();
    }

    private void PlayAudioForScene(string sceneName)
    {
        if (sceneName == "FrontEnd")
        {
            PlayClip(0);
        }
        else if (sceneName == "SampleScene")
        {
            PlayClip(1);
        }
    }

    public void PlayClip(int clipNumber)
    {
        if (clipNumber < 0 || clipNumber >= clips.Length)
        {
            return;
        }

        
        audioSource.volume = volumeSlider.value;

        
        audioSource.PlayOneShot(clips[clipNumber], 1f);  
    }



    public void StopClip()
    {
        audioSource.Stop();
    }

    public void OnVolumeChanged(float volume)
    {
        audioSource.volume = Mathf.Clamp(volume, 0f, 1f);
    }
}
