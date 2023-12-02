using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Common.Manager
{
    public class GameManager : ManagerBase
    {
        // Load a scene by name
        public void LoadScene(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }

        // Asynchronously load a scene by name
        public void LoadSceneAsync(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        }

        // Load the next scene in the build index
        public void LoadNextScene()
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneIndex);
        }

        // Reload the current scene
        public void ReloadScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // Get the name of the current scene
        public string GetCurrentSceneName()
        {
            return SceneManager.GetActiveScene().name;
        }

        // Add more methods as needed for your specific use case

        // Example: Unload a scene by name
        public void UnloadScene(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName);
        }
    }
}
