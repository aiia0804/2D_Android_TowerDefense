using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slimeproject_SkillSystem
{
    public abstract class SkillBase : MonoBehaviour
    {
        public SkillData data;
        internal SkillSchedule _skillSchedule;
        public virtual void Cancel() { }
        public virtual void Cast(Vector3 touchPos, GameObject target) { }
        public virtual void Cast(Transform plyaerUnitList, Transform AIList) { }

        public void Awake()
        {
            _skillSchedule = GetComponentInParent<SkillSchedule>();
        }

        public void StartSkill()
        {
            _skillSchedule.StartSkill(this);
        }
    }
}