using UnityEngine;

namespace Slimeproject_SkillSystem
{
    public abstract class Skill_ScreenTapBase : SkillBase
    {

        [SerializeField] float raidous;

        private FadeOut _fadeOut;

        private new void Awake()
        {
            base.Awake();
            _fadeOut = FindObjectOfType<FadeOut>();
        }

        public override void Cast(Vector3 touchPos, GameObject target)
        {
            if (target == null)
            {
                return;
            }
            //_fadeIn.ProcessVfx(target.transform.position, raidous, data.vfxSprite);
            CastByEach();
        }


        public abstract void CastByEach();





    }
}