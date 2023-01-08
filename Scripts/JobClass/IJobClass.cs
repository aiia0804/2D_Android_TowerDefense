using System.Collections.Generic;
using UnityEngine;
using SlimeProject_ClassificationSheet;


namespace SlimeProject_JobClass
{
    public interface IJobClass
    {
        /// <summary>
        /// Unit Attack 範圍Attack 有遠近LIST代入
        /// </summary>
        /// <param name="targets"> 進入範圍內的LIST</param>
        /// <param name="defendAbleEnemy">正在攻擊此角的的LIST</param>
        /// <param name="damage">攻擊傷害</param>
        void AttackPrepare(List<GameObject> targets, float damage, ElementType type, UnitType unitType, float radious);

        void StopAttack();

    }

}