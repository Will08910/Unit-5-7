using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int health;
    public GameObject player;
    public GameObject canvas1;
    private static bool sceneLoaded = false;

    public string sceneName1 = "FrontEnd";
    public string sceneName2 = "SampleScene";
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                print("do not destroy");
            }
            else
            {
                print("do destroy");
                Destroy(gameObject);
            }
        }
    }

    public void GetHealth()
    {
        print(health);
    }

    void Start()
    {
        if (!sceneLoaded)
        {
            SceneManager.LoadScene(sceneName1);

            sceneLoaded = true;
        }
        health = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            player.SetActive(false);
        }
    }

    public void StartPressed()
    {
        SceneManager.LoadScene(sceneName2);
    }
}
