using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SlimeProject_GameControlSystem
{
    public class Scene_Controller : MonoBehaviour
    {
        [SerializeField] int timeToWait = 4;
        //debug purpose
        [SerializeField]　int currentSceneIndex;
        public void Start()
        {
            currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            //等有 Splash Screen Scene 在使用
            // if (currentSceneIndex == 0)
            // {
            //     StartCoroutine(LoadDelay());
            // }
        }

        IEnumerator LoadDelay()
        {
            yield return new WaitForSeconds(timeToWait);
            loadNextScene();
        }

        public void loadNextScene()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(currentSceneIndex + 1);

        }

        public void replayTheScene()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(currentSceneIndex);
        }

        public void backToMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu");
        }

        public void loadOptionScene()
        {
            SceneManager.LoadScene("Option Screen");
        }

        public void loadGameOverScene()
        {
            SceneManager.LoadScene("Game Over Screen");
        }

        public void quitgame()
        {
            Application.Quit();
        }
    }
}
