using System.Collections.Generic;
using UnityEngine;
using SlimeProject_ClassificationSheet;

namespace SlimeProject_PlayerUnitManager
{
    public class PlayerUnit_RandomGenerator
    {
        List<PlayerUnitType> playerUnitTypeList = new List<PlayerUnitType>();
        public bool isInalitzied = false;

        private PlayerUnitManager _playerUnitManager;

        public PlayerUnit_RandomGenerator(PlayerUnitManager manager)
        {
            _playerUnitManager = manager;
        }

        private void SetUpList()
        {
            IEnumerable<PlayerUnitType> type = _playerUnitManager.GetEquipedUnitList();
            foreach (var i in type)
            {
                playerUnitTypeList.Add(i);
            }
        }

        public PlayerUnitType GetRandaomType()
        {
            if (!isInalitzied)
            {
                SetUpList();
                isInalitzied = true;
            }
            int randomIndex = (int)Random.Range(0, playerUnitTypeList.Count);
            return playerUnitTypeList[randomIndex];
        }



    }
}