using System;
using System.Collections.Generic;
using UnityEngine;
using SlimeProject_PlayerUnitManager;
using Slimeproject_SkillSystem;
using SlimeProject_PlayerUnit;
using SlimeProject_GridSystem;


namespace SlimeProject_UnitGeneratorSystem
{
    public class PlayerUnit_Depolyer : MonoBehaviour
    {
        [SerializeField] Transform playerUnitPool;
        [SerializeField] float radnomVectorRange;

        public event Action deployCompleted;

        //Cache
        private PlayerUnitManager _playerUnitManager;
        private SkillSchedule _skillSchedule;
        private Skill_Enery_Charging _skill_Enery_Charging;

        //Conditions
        private bool _depolyMode = false;

        private void Awake()
        {
            _playerUnitManager = FindObjectOfType<PlayerUnitManager>();
            _skillSchedule = GetComponentInParent<SkillSchedule>();
            _skill_Enery_Charging = GetComponentInParent<Skill_Enery_Charging>();
            _skillSchedule.UpdatePlayerUnitist(playerUnitPool);
        }

        public void StartToDepoly(SlimeProject_GridSystem.Grid grid)
        {
            var _randomVector = UnityEngine.Random.Range(-radnomVectorRange, radnomVectorRange);

            Vector3 targetPos = new Vector3(grid.transform.position.x + _randomVector,
                                                grid.transform.position.y + _randomVector,
                                                grid.transform.position.z);

            GameObject playerUnit = _playerUnitManager.Generate();
            playerUnit.GetComponent<PlayerUnit_Base>().SetUpBasicStatus(_playerUnitManager, _skill_Enery_Charging);
            playerUnit.transform.SetParent(playerUnitPool);
            playerUnit.transform.position = targetPos;
            deployCompleted?.Invoke();
        }

    }
}