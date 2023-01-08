using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeProject_ClassificationSheet;

namespace SlimeProject_PlayerUnit_DataBase
{
    [CreateAssetMenu(fileName = "__Database", menuName = "DataBase/PlayerUnit/Database", order = 1)]
    public class PlayerUnit_DataBase : ScriptableObject
    {
        public PlayerUnitType unitType;
        public GameObject unitPrefab;
        public DepolyConditions depolyConditions;
        public PlayerUnitConditions playUnitConditions;


        [System.Serializable]
        public class DepolyConditions
        {
            public Sprite image;
            public int resoucesSpend;
            [TextArea]
            public string description;
        }

        [System.Serializable]
        public class PlayerUnitConditions
        {
            [Header("能力值")]
            public ElementType elementType;
            public float hpPoints;
            public float damageRadious;
            public float attackDamage;
            public float defense;
            public float attacdCD;
            public float movingSpeed;
            public float charingAmount;

            //可以留著?
            public AttackType attackType;
            public JobType jobType;

        }


    }
}
