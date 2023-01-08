using System;
using UnityEngine;
using System.Collections;
using SlimeProject_ClassificationSheet;

namespace SlimeProject_Combat
{
    public class Projectioe_RangeExplosive : MovingProj_BaseControl
    {

        [SerializeField] float animationTime;
        public override void EffectByEach()
        {
            StartCoroutine(CheckTheDistance());
        }

        private IEnumerator CheckTheDistance()
        {
            while (this.transform.position.y > targetPos.y)
            {
                yield return new WaitForEndOfFrame();
            }
            startToMove = false;
            Invoke(nameof(Explosive), animationTime);
            GetComponentInChildren<Animator>().SetTrigger("VFXOn");

        }

        private void Explosive()
        {
            float radious = transform.lossyScale.x;

            Collider[] allTargets = Physics.OverlapSphere(this.transform.position, radious, targetLayer);

            foreach (var target in allTargets)
            {
                Health target_Helath = target.GetComponentInParent<Health>();
                if (target_Helath.isDeath) { return; }

                if (projectileType == DamageType.physicDamage)
                {
                    target_Helath.TakePhsicalDamage(damage);
                }
                else
                {
                    target_Helath.TakeElementDamage(damage, elementType);
                }
            }

        }
    }
}