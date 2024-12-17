using UnityEngine;

public class KillSwitch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Killswitch()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
