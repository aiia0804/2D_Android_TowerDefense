using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeProject_ClassificationSheet;

namespace SlimeProject_Combat
{

    [CreateAssetMenu(fileName="__Database",menuName="DataBase/Projectiles/ProjectilesDatabase",order=1)]
    public class Projectiles_DataBase : ScriptableObject
    {
        public Projectiles_Type type;
        public float statusOccurPerecentage;
        public float elementCreatPercentage;
        public float elementGenerateQty;
        public ElementType elementType;
        

    }
}