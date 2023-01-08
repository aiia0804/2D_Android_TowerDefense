using UnityEngine;
using SlimeProject_PlayerUnit;
using System.Collections.Generic;

namespace Slimeproject_SkillSystem
{
    public abstract class Skill_GlobalTypeBase : SkillBase
    {
        // 找到相對應的LIST 並產生效果 (沒有LIST的技能LIST 為NULL)
        // 技能結束後要連接SKILL SCHEDULRE
        // 一套技能使用效果系統(Corutiune 時間內倒數) 被繼承技能CALL
        // 技能結束後由這裡CALL SCHEDULER

        public Transform slimeList;
        public Transform AILList;

        public override void Cast(Transform playerUnitList, Transform AIList)
        {
            this.slimeList = playerUnitList;
            this.AILList = AIList;
            CastByEach();
            Invoke(nameof(SkillFinish), 2f);
        }
        public abstract void CastByEach();
        internal void SkillFinish()
        {
            _skillSchedule.SkillModeOff();
        }
    }
}