using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    public GameObject Canvas;
    Animator animator;
    private AudioSource audioSource;
    public AudioClip clip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(clip != null )
        {
            audioSource.clip = clip;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Canvas.SetActive(true);
            audioSource.Play();
        }
    }
}
