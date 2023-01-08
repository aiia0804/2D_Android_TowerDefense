using UnityEngine;
using SlimeProject_ClassificationSheet;

namespace SlimeProject_Combat
{
    public class Projectile_OneTarget : MovingProj_BaseControl
    {
        public override void EffectByEach()
        {
            Invoke(nameof(DestroyThis), destroyTime);
        }
        private void OnTriggerEnter(Collider other)
        {

            if (other.transform.tag == "Enemy" && inputType == UnitType.Player
                || other.transform.tag == "Slime" && inputType == UnitType.AI)
            {
                Health target_Helath = other.GetComponentInParent<Health>();
                if (target_Helath.isDeath) { return; }

                startToMove = false;

                if (projectileType == DamageType.physicDamage)
                {
                    target_Helath.TakePhsicalDamage(damage);
                }
                else
                {
                    target_Helath.TakeElementDamage(damage, elementType);
                }

                TryGetComponent<Projectiles_Effect>(out Projectiles_Effect effect);
                if (effect) { effect.EffectAfterTouch(this.transform.position, other.transform); }
                DestroyThis();
            }
        }
    }
}