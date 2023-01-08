using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeProject_Combat;
using System.Linq;
using SlimeProject_ClassificationSheet;
using Slimeproject_Tools;


namespace SlimeProject_JobClass
{
    public class JobClass_Melee : MonoBehaviour, IJobClass
    {
        private DirectionHandler _direcHandler = new DirectionHandler();

        public void AttackPrepare(List<GameObject> targets, float damage, ElementType type, UnitType unitType, float radious)
        {
            float lowestHP = Mathf.Infinity;
            GameObject target = null;

            for (int i = 0; i < targets.Count; i++)
            {
                if (targets[i] == null)
                {
                    targets.Remove(targets[i]);
                    continue;
                }
                if (targets[i].GetComponent<Health>().GetCurrentHP() < lowestHP)
                {
                    target = targets[i].gameObject;
                }
            }
            if (target == null) { return; }
            _direcHandler.SetData(transform.position, target.transform.position, this.transform, unitType);
            GetComponentInChildren<Fighter>().ProcessToAttack(target, damage);
        }

        public void StopAttack()
        {
            _direcHandler.SetDirectionBack();
            GetComponentInChildren<Fighter>().ProcessToStop();
        }
    }
}