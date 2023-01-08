using UnityEngine;
using SlimeProject_ClassificationSheet;

namespace SlimeProject_CombatElement
{
    //To adjust the damage between each element

    [CreateAssetMenu(fileName = "Element_DamageCalculation", menuName = "DataBase/Element/Element_DamageCalculation", order = 0)]
    public class Element_DamageCalculateDataBase : ScriptableObject
    {
        public DamageAdditive[] additiveList;

        [System.Serializable]
        public class DamageAdditive
        {
            public ElementType type;
            public int additive;
        }

    }
}