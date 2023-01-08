using System.Collections.Generic;
using UnityEngine;
using SlimeProject_Combat;
using SlimeProject_ClassificationSheet;
using SlimeProject_PlayerUnit;

namespace SlimeProject_JobClass
{
    public class JobClass_RangeAttacker : MonoBehaviour, IJobClass
    {
        [SerializeField]
        public void AttackPrepare(List<GameObject> targets, float damage, ElementType type, UnitType unitType, float radious)
        {
            if (targets.Count > 0)
            {
                GetComponentInChildren<RangeAttacker>().ProcessToAttack(damage, GetComponent<PlayerUnit_Base>().conditions.damageRadious);
            }
        }

        public void StopAttack()
        {
            GetComponentInChildren<RangeAttacker>().ProcessToStop();
        }
    }
}