using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SlimeProject_AIDataBase
{
    [Serializable]
    public class AIDataBase
    {
        public int id;
        public int generatePoints;
        public SlimeProject_ClassificationSheet.ElementType elementType;
        public float attackDamage;
        /// <summary>
        /// 移動格數能力
        /// </summary>
        public int mvoingPoint;
        /// <summary>
        /// 移動速度
        /// </summary>
        public float attackCD;
        public float movingSpeed;
        public float defense;
        public float healthPoint;
        public int gainRescoures;
        public int damageToPoints;
        //AI gameobjtct prefab
        public GameObject prefab;
        public float damgeRadious;

    }

}
