using UnityEngine;
using SlimeProject_ClassificationSheet;


namespace SlimeProject_StatusEventSystem
{
    public abstract class ScriptableBuff : ScriptableObject
    {
        /// <summary>
        /// 此Status的TYPE
        /// </summary>
        public StatusType statusType;

        /// <summary>
        /// Status的持續長度
        /// </summary>
        public float Duration;

        /// <summary>
        /// 此Status的持續是否可以疊加
        /// </summary>
        public bool IsDurationStacked;

        /// <summary>
        /// 此Status的效果是否可以疊加
        /// </summary>
        public bool IsEffectStacked;

        public abstract TimedBuff InitializeStatusEvent(GameObject obj);

    }
}