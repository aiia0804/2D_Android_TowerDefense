using UnityEngine;

namespace SlimeProject_GameControlSystem
{
    public class GameStatusManager : MonoBehaviour
    {
        [SerializeField] private float heartPoints;

        //TODO- When conditons change, the difficulity will change
        //影响LEVEL 難度

        private float gameLevelAdditive;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public float GetHeartPoints()
        {
            return heartPoints;
        }

        public void AddLeveAdditive(float additive)
        {
            gameLevelAdditive += additive;
        }
    }
}