using UnityEngine;

namespace SlimeProject_StatusEventSystem
{
    [CreateAssetMenu(fileName = "Speed Buff", menuName = "DataBase/Status Event/Speed Buff", order = 0)]
    public class ScriptableSpeedBuff : ScriptableBuff
    {
        public float SpeedIncrease;

        public override TimedBuff InitializeStatusEvent(GameObject obj)
        {
            return new TimedSpeedBuff(this, obj);
        }
    }
}
