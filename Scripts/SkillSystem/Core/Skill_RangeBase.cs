using System;
using System.Collections.Generic;
using UnityEngine;

namespace Slimeproject_SkillSystem
{
    public abstract class Skill_RangeBase : SkillBase
    {
        public float raidous;
        [SerializeField] LayerMask targetLayer;

        internal Vector3 touchPos;
        internal List<GameObject> targets;
        private FadeOut _fadeOut;

        private new void Awake()
        {
            base.Awake();
            _fadeOut = FindObjectOfType<FadeOut>();
        }
        public override void Cast(Vector3 touchPos, GameObject target)
        {
            this.touchPos = touchPos;
            if (targets == null)
            {
                targets = new List<GameObject>();
            }

            _fadeOut.ProcessAreaVfx(touchPos, raidous, data.vfxSprite);
            BuildTheList(touchPos);
            CastByEach();
        }

        private void BuildTheList(Vector3 touchPos)
        {
            targets.Clear();

            Collider[] allTargets = Physics.OverlapSphere(touchPos, raidous, targetLayer);
            foreach (var target in allTargets)
            {
                targets.Add(target.gameObject);
            }
        }
        public abstract void CastByEach();

    }
}