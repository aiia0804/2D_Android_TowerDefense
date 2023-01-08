using UnityEngine;
using SlimeProject_ClassificationSheet;

namespace SlimeProject_StatusEventSystem
{
    [CreateAssetMenu(fileName = "Damaged Buff", menuName = "DataBase/Status Event/Burning Buff", order = 0)]
    public class ScriptableBurningDebuff : ScriptableBuff
    {
        [Tooltip("傷害百分比  X/100 ")]
        public float statusDamageCoefficient;
        public ElementType elementType;

        public override TimedBuff InitializeStatusEvent(GameObject obj)
        {
            return new TimedBurningDebuff(this, obj);
        }
    }
}
