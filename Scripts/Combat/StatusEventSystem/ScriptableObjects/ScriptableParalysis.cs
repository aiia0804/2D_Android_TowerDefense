using UnityEngine;
namespace SlimeProject_StatusEventSystem

{
    [CreateAssetMenu(fileName = "Damaged Buff", menuName = "DataBase/Status Event/Paralysis Buff", order = 0)]

    public class ScriptableParalysis : ScriptableBuff
    {
        public override TimedBuff InitializeStatusEvent(GameObject obj)
        {
            return new TimeParalysisStatus(this, obj);
        }
    }
}