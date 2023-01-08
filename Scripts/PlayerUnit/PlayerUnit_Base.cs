using UnityEngine;
using SlimeProject_SlimeManager;
using SlimeProject_PlayerUnit_DataBase;
using SlimeProject_Combat;
using SlimeProject_GridSystem;
using SlimeProject_ClassificationSheet;
using Slimeproject_SkillSystem;


namespace SlimeProject_PlayerUnit
{
    public class PlayerUnit_Base : MonoBehaviour
    {
        public Health health;
        public RowGridSystem rowGrid;
        public Skill_Enery_Charging _skill_Enery_Charging { get; set; }


        [Header("UNIT 種類, 狀況")]
        public PlayerUnitType unitType;
        public SlimeProject_PlayerUnit_DataBase.PlayerUnitConditions conditions;

        //Cache
        private PlayerUnitManager _manager;
        [HideInInspector]
        public UnitType unitType;

        public void Awake()
        {
            health = GetComponent<Health>();
        }

        private void OnEnable()
        {
            health.UnitOnDie += ProcessDaeth;
        }

        private void OnDisable()
        {
            health.UnitOnDie -= ProcessDaeth;
        }

        public void SetUpBasicStatus(PlayerUnitManager manager, Skill_Enery_Charging energy_system)
        {
            _manager = manager;
            conditions = _manager.GetUnitConditions(unitType);
            _skill_Enery_Charging = energy_system;
            GetComponent<Health>().SetUpData(conditions.hpPoints, conditions.elementType, conditions.defense);
            GetComponent<SphereCollider>().radius = conditions.damageRadious;
            unitType = UnitType.Player;
        }
        private void ReturnUnit()
        {
            _manager.Destroy(this.gameObject);
        }
        public virtual void ProcessDaeth()
        {
            GetComponent<Energy_Charger>().BeTheFertilizer();
            Invoke(nameof(ReturnUnit), 1);
        }

    }
}