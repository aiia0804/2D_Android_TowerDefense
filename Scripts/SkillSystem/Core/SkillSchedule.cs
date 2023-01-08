using System;
using System.Collections.Generic;
using UnityEngine;
namespace Slimeproject_SkillSystem
{
    public class SkillSchedule : MonoBehaviour
    {
        public SkillBase currentSkill;
        public event Action skillModeOn;
        public event Action skillModeOff;

        private Transform playerUnitList;
        public Transform AIList;

        public void StartSkill(SkillBase newSkill)
        {
            if (currentSkill != newSkill)
            {
                currentSkill = newSkill;
            }

            skillModeOn?.Invoke();

            if (currentSkill.data.skillType == SkillType.golbalType)
            {
                currentSkill.Cast(playerUnitList, AIList);
                Invoke(nameof(CancelSkill), 2f);
            }
        }

        public void ProcessSkill(Vector3 castPos, GameObject target)
        {
            switch (currentSkill.data.skillType)
            {
                case SkillType.range:
                    currentSkill.Cast(castPos, target);
                    break;

                case SkillType.tap2Unit:
                    if (target == null) { return; }
                    currentSkill.Cast(target.transform.position, target);
                    break;
            }
            skillModeOff?.Invoke();
        }

        private Dictionary<GameObject, Transform> temporyList = new Dictionary<GameObject, Transform>();
        public void UpdateAIList(Transform AIList)
        {
            this.AIList = AIList;
        }
        public void UpdatePlayerUnitist(Transform playerUnitList)
        {
            this.playerUnitList = playerUnitList;
        }
        public void SkillModeOff()
        {
            skillModeOff?.Invoke();
        }

        public void CancelSkill()
        {
            currentSkill = null;
            skillModeOff?.Invoke();
        }
    }
}
