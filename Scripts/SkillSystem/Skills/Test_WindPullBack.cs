using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeProject_AI;
using SlimeProject_Combat;

namespace Slimeproject_SkillSystem

{
    public class Test_WindPullBack : Skill_RangeBase
    {
        [SerializeField] GameObject vfxPrefab;
        public override void CastByEach()
        {
            GameObject vfx = Instantiate(vfxPrefab, touchPos, Quaternion.identity);
            vfx.transform.SetParent(this.transform);

            if (targets.Count == 0) { return; }
            foreach (var target in targets)
            {
                AI_Base AI = target.GetComponentInParent<AI_Base>();
                if (!target.GetComponentInParent<Health>().isDeath)
                {
                    AI.PausingSystem();

                    ///給負值 會往後走
                    target.GetComponentInParent<AI_Move>().Move(-(int)data.parameter1);
                }
            }






        }
    }
}