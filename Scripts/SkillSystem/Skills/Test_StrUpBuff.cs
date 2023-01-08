using UnityEngine;
using SlimeProject_PlayerUnit;
using SlimeProject_StatusEventSystem;
using SlimeProject_ClassificationSheet;

namespace Slimeproject_SkillSystem
{
    public class Test_StrUpBuff : Skill_GlobalTypeBase
    {
        //To gain the attack of all current unit on field

        [SerializeField] StatusType statusType;
        private StatusEventManager _statusEventManager;

        private new void Awake()
        {
            base.Awake();
            _statusEventManager = FindObjectOfType<StatusEventManager>();

        }
        /// <summary>
        /// data.parameter = str up points.
        /// </summary>
        public override void CastByEach()
        {
            var targets = slimeList.GetComponentsInChildren<PlayerUnit_Base>();
            foreach (var target in targets)
            {
                target.GetComponent<StatusEventHandler>().AddStatusEvent(_statusEventManager.
                GetStatusEvent(statusType).InitializeStatusEvent(target.gameObject), data.parameter1);
                target.GetComponentInChildren<UnitStatusVFXHandler>().HandleVFX(data.vfxSprite);
            }
        }
    }
}