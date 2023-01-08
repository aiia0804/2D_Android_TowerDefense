using UnityEngine;
using System.Collections.Generic;
using SlimeProject_ClassificationSheet;

namespace SlimeProject_CombatElement
{
    [CreateAssetMenu(fileName = "ElementDataBase", menuName = "DataBase/Element/ElementDataBase", order = 0)]
    public class ElementDataBase : ScriptableObject
    {
        public ElementType type;
        public GameObject elementPrefab;
        public Element_DamageCalculateDataBase elementDamageList;


    }
}