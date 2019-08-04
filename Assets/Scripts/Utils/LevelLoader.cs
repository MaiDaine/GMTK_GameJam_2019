using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int maxLevel;

    private int levelCount = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void OnNextLevel()
    {
        levelCount++;
        if (levelCount < maxLevel)
            SceneManager.LoadScene(levelCount);
        else
            Application.Quit();
    }
}
