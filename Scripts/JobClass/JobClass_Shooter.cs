using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using SlimeProject_Combat;
using SlimeProject_ClassificationSheet;
using Slimeproject_Tools;

namespace SlimeProject_JobClass
{
    public class JobClass_Shooter : MonoBehaviour, IJobClass
    {
        [SerializeField] GameObject projectilePrefab;
        private DirectionHandler _direcHandler = new DirectionHandler();

        public void AttackPrepare(List<GameObject> targets, float damage, ElementType type, UnitType unitType, float radious)
        {
            float lowestHP = Mathf.Infinity;
            GameObject target = null;

            foreach (var enemy in targets)
            {
                if (enemy.GetComponent<Health>().GetCurrentHP() < lowestHP)
                {
                    target = enemy.gameObject;
                }
                _direcHandler.SetData(transform.position, target.transform.position, this.transform, unitType);
            }
            GetComponentInChildren<Shooter>().ProcessToAttack(target, damage, projectilePrefab, unitType);
        }

        public void StopAttack()
        {
            _direcHandler.SetDirectionBack();
            GetComponentInChildren<Shooter>().ProcessToStop();
        }
    }
}

