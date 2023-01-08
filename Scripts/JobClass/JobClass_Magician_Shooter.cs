using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SlimeProject_JobClass;
using SlimeProject_ClassificationSheet;
using SlimeProject_Combat;
using Slimeproject_Tools;

public class JobClass_Magician_Shooter : MonoBehaviour, IJobClass
{
    //[SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject elementProjectilePrefab;
    [SerializeField] float randomVectror;
    [SerializeField] string targetLayer;
    //private Queue<GameObject> projectiles = new Queue<GameObject>();
    bool magicMissile = false;
    private DirectionHandler _direcHandler = new DirectionHandler();



    public void AttackPrepare(List<GameObject> targets, float damage, ElementType type, UnitType unitType, float radious)
    {
        float lowestHP = Mathf.Infinity;
        GameObject target = null;

        //Intereact with element first.

        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i] == null)
            {
                targets.Remove(targets[i]);
                continue;
            }
            if (LayerMask.LayerToName(targets[i].layer) == targetLayer)
            {
                target = targets[i].transform.parent.gameObject;
            }
        }

        //Then enemy.

        if (target == null && targets.Count > 0)
        {
            magicMissile = false;
            for (int i = 0; i < targets.Count; i++)
            {
                if (targets[i] == null)
                {
                    targets.Remove(targets[i]);
                    continue;
                }
                if (LayerMask.LayerToName(targets[i].layer) == targetLayer) { continue; }

                if (targets[i].GetComponent<Health>().GetCurrentHP() < lowestHP)
                {
                    target = targets[i].gameObject;
                }
            }
        }
        _direcHandler.SetData(transform.position, target.transform.position, this.transform, unitType);
        GetComponentInChildren<MagicShooter>().ProcessToAttack(target, damage, elementProjectilePrefab, targetLayer);

    }

    public void StopAttack()
    {
        GetComponentInChildren<MagicShooter>().ProcessToStop();
    }
}