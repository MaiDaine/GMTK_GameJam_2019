using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int maxLevel;

    private int levelCount = 0;
    private bool locked = false;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void OnNextLevel()
    {
        if (locked)
            return;
        locked = true;
        levelCount++;
        if (levelCount < maxLevel)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(levelCount);
        }
        else
            Application.Quit();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        locked = false;
    }
}
