using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
    public void LoadSceneByName(string sceneName2)
    {
        SceneManager.LoadScene(sceneName2);
    }
}
