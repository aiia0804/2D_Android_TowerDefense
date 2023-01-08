using UnityEngine;
using SlimeProject_PlayerUnit;
using SlimeProject_ClassificationSheet;
using SlimeProject_Combat;

namespace Slimeproject_SkillSystem
{
    public class Energy_Charger : MonoBehaviour
    {
        private ElementType _type;
        private PlayerUnit_Base _playerUnit;
        private Health _playerUnitHealth;
        private Skill_Enery_Charging _skill_EnergSystem;
        private float fertilizerAmount;

        // Need to wait Unit_Base set up, so call in Start()
        private void Start()
        {
            SetUp();
        }

        private void SetUp()
        {
            _playerUnitHealth = GetComponent<Health>();
            _playerUnit = GetComponent<PlayerUnit_Base>();
            _type = _playerUnit.conditions.elementType;
            _skill_EnergSystem = _playerUnit._skill_Enery_Charging;
            fertilizerAmount = _playerUnit.conditions.charingAmount;
        }

        public void BeTheFertilizer()
        {
            _skill_EnergSystem.ChargeEnergy(_type, fertilizerAmount, this.transform.position);
        }
    }
}
