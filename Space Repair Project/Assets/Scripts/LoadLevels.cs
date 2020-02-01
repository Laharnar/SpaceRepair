using UnityEngine;

public class LoadLevels:MonoBehaviour {

    public string playSceneName;
    public string mainMenuSceneName;

    public void PlayNewGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(playSceneName);
    }

    public void ExitToMainMenu()
    {
        UnityEngine.SceneManagement.
            SceneManager.LoadScene(mainMenuSceneName);
    }
}
