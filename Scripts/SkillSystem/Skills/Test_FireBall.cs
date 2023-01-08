using UnityEngine;
using SlimeProject_Combat;
using SlimeProject_ClassificationSheet;

namespace Slimeproject_SkillSystem
{
    public class Test_FireBall : Skill_RangeBase
    {
        [SerializeField] GameObject fireBall;
        [SerializeField] float defaultHeight;

        public override void CastByEach()
        {
            Vector3 tragetPos = new Vector3(touchPos.x, touchPos.y + defaultHeight, touchPos.z);
            GameObject missile = Instantiate(fireBall, tragetPos, Quaternion.identity);
            missile.GetComponent<Transform>().localScale = new Vector3(raidous / 2, raidous / 2, raidous / 2);
            missile.GetComponent<MovingProj_BaseControl>().SetUpTarget(data.parameter1, touchPos, UnitType.Player);
        }
    }
}