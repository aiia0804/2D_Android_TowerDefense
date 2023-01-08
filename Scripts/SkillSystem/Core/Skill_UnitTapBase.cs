using UnityEngine;

namespace Slimeproject_SkillSystem
{
    public abstract class Skill_UnitTapBase : SkillBase
    {
        // debug purpose serializfield
        internal GameObject target;
        [SerializeField] float raidous;

        private ZoomIn _fadeIn;

        private new void Awake()
        {
            base.Awake();
            _fadeIn = FindObjectOfType<ZoomIn>();
        }

        public override void Cast(Vector3 touchPos, GameObject target)
        {
            if (target == null)
            {
                return;
            }
            this.target = target;
            _fadeIn.ProcessVfx(target.transform.position, raidous, data.vfxSprite);
            CastByEach();
        }


        public abstract void CastByEach();





    }
}