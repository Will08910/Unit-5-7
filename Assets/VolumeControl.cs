using UnityEngine;
using UnityEngine.UI;
public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (volumeSlider != null && audioSource != null)
        {
            volumeSlider.value = audioSource.volume;
        }
    }

    public void SetVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetVolume(volumeSlider.value);
    }
}
