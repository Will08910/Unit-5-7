using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject Canvas2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Run()
    {
        Canvas.SetActive(false);
        Canvas2.SetActive(true);
    }
}
