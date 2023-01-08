using UnityEngine;
using SlimeProject_Combat;
using SlimeProject_ClassificationSheet;
using SlimeProject_StatusEventSystem;

namespace Slimeproject_SkillSystem
{
    public class Test_SummonElectric : Skill_UnitTapBase
    {
        [SerializeField] GameObject electric;
        [SerializeField] StatusType statusType;
        [SerializeField] float damage;


        public override void CastByEach()
        {
            Instantiate(electric, target.transform.position, Quaternion.identity);
            target.GetComponent<StatusEventHandler>().AddStatusEvent
            (StatusEventManager.Instance.GetStatusEvent(statusType).InitializeStatusEvent(target.gameObject), damage);

        }
    }
}