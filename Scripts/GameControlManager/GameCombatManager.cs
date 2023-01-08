using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SlimeProject_GameControlSystem
{
    public class GameCombatManager : MonoBehaviour
    {
        private void Awake()
        {

        }

        public void GameFail()
        {
#if UNITY_EDITOR
            Debug.Log("GG");
#endif
        }

        public void GameWin()
        {

        }

        public void LoadnextScene()
        {

        }




    }
}