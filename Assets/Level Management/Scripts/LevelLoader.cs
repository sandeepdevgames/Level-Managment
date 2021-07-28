using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private static int mainMenuIndex = 1;

    public static void LoadNextLevel()
    {
        int nextSceneIndex = ((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);

        nextSceneIndex = Mathf.Clamp(nextSceneIndex, mainMenuIndex, nextSceneIndex);

        SceneManager.LoadSceneAsync(nextSceneIndex);
    }

    public static void LoadLevel(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(levelIndex);
        else
            Debug.LogWarning("Load Game Erro: invalid level index");
    }

    public static void LoadLevel(string levelName)
    {
        if (Application.CanStreamedLevelBeLoaded(levelName))
            SceneManager.LoadScene(levelName);
        else
            Debug.LogWarning("Load Game Erro: invalid level levelName");
    }

    public static void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void LoadMainMenuLevel ()
    {
        LoadLevel(mainMenuIndex);
    }
}
