using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SlimeProject_GameControlSystem;

namespace SlimeProject_UI
{
    public class HeartDisplay : MonoBehaviour
    {
        [SerializeField] int heartPoints;
        [SerializeField] TextMeshProUGUI pointsDisplay;
        GameCombatManager gameManager;

        private void Awake() 
        {
            gameManager=FindObjectOfType<GameCombatManager>();
            UpdatePoints(heartPoints);
        }

        public void TakeDamage(int point)
        {
            if(heartPoints>0)
            {
                heartPoints-=point;
                UpdatePoints(heartPoints);

                if(heartPoints<=0)
                {
                    gameManager.GameFail();
                }
            }
        }

        private void UpdatePoints(int points)
        {
            pointsDisplay.text=points.ToString();
        }

    }
}