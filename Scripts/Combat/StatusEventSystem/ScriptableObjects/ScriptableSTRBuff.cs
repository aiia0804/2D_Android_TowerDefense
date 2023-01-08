using UnityEngine;

namespace SlimeProject_StatusEventSystem
{
    [CreateAssetMenu(fileName = "Str Buff", menuName = "DataBase/Status Event/Str Buff", order = 0)]
    public class ScriptableSTRBuff : ScriptableBuff
    {
        public override TimedBuff InitializeStatusEvent(GameObject obj)
        {
            return new TimedSTRBuff(this, obj);
        }
    }
}
