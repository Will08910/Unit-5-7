using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip[] clips;
    private AudioSource audioSource;
    private AudioSource audioSource2;

    public Slider volumeSlider;
    public Slider SFXSlider;

    private const string MUSIC_VOLUME_KEY = "MusicVolume";
    private const string SFX_VOLUME_KEY = "SFXVolume";

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

        if (audioSource2 == null)
        {
            audioSource2 = GameObject.Find("SFXAudioSource")?.GetComponent<AudioSource>();
        }

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
        if (audioSource2 == null)
        {
            audioSource2 = GameObject.Find("SFXAudioSource")?.GetComponent<AudioSource>();
        }

        if (volumeSlider == null)
        {
            volumeSlider = GameObject.FindGameObjectWithTag("VolumeSlider")?.GetComponent<Slider>();
        }

        if (volumeSlider != null)
        {
            float savedMusicVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, 0.5f);
            volumeSlider.value = savedMusicVolume;
            audioSource.volume = savedMusicVolume;

            volumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        }

        if (SFXSlider == null)
        {
            SFXSlider = GameObject.FindGameObjectWithTag("SFX Slider")?.GetComponent<Slider>();
        }

        if (SFXSlider != null)
        {
            float savedSFXVolume = PlayerPrefs.GetFloat(SFX_VOLUME_KEY, 0.5f);
            SFXSlider.value = savedSFXVolume;
            audioSource2.volume = savedSFXVolume;

            SFXSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
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

        audioSource.PlayOneShot(clips[clipNumber], 1f);
    }

    public void StopClip()
    {
        audioSource.Stop();
    }

    public void OnMusicVolumeChanged(float volume)
    {
        audioSource.volume = Mathf.Clamp(volume, 0f, 1f);

        PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, volume);
        PlayerPrefs.Save();
    }

    public void OnSFXVolumeChanged(float volume)
    {
        audioSource2.volume = Mathf.Clamp(volume, 0f, 1f);

        PlayerPrefs.SetFloat(SFX_VOLUME_KEY, volume);
        PlayerPrefs.Save();
    }
}
