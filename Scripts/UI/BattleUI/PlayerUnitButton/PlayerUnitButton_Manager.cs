using UnityEngine;
using SlimeProject_PlayerUnitManager;
using System.Collections.Generic;
using SlimeProject_BattleTimer;

namespace SlimeProject_UI
{

    public class PlayerUnitButton_Manager : MonoBehaviour
    {
        [SerializeField] PlayerUnitButton_Button buttonBoxPrefab;
        private PlayerUnitManager _playerUnitManager;
        private PlayerUnit_RandomGenerator _randomGenator;
        [SerializeField] private int gnerateQty;

        private void Start()
        {
            ClearDisplay();
            _playerUnitManager = FindObjectOfType<PlayerUnitManager>();
            if (_randomGenator == null)
            {
                _randomGenator = new PlayerUnit_RandomGenerator(_playerUnitManager);
            }
        }
        private void OnEnable()
        {
            Battle_Timer.timeUp += GenerateuButton;
        }
        private void OnDisable()
        {
            Battle_Timer.timeUp -= GenerateuButton;
        }

        private void ClearDisplay()
        {
            foreach (Transform box in transform)
            {
                Destroy(box.gameObject);
            }
        }

        private void GenerateuButton()
        {
            for (int i = 0; i < gnerateQty; i++)
            {
                if (this.transform.childCount >= 6) { return; }//暫定最大5個
                var buttonBox = Instantiate(buttonBoxPrefab, transform);
                PlayerUnitType type = _randomGenator.GetRandaomType();

                buttonBox.SetUp(type, GetImage(type), GetRescouresSpend(type));
            }
        }

        private int GetRescouresSpend(PlayerUnitType type)
        {
            return _playerUnitManager.GetRescouresSpend(type);
        }

        private Sprite GetImage(PlayerUnitType type)
        {
            return _playerUnitManager.GetImage(type);
        }

    }
}