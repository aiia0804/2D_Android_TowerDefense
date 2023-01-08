using UnityEngine;
namespace SlimeProject_Combat
{
    public class RangeAttacker : CarrierBase
    {
        [SerializeField] ParticleSystem ps;

        public override void Attack()  // call bal animation
        {
            Collider[] hitTargets = Physics.OverlapSphere(this.transform.position, _raidous);
            foreach (Collider hitTarget in hitTargets)
            {
                hitTarget.TryGetComponent<Health>(out Health target);
                if (target && hitTarget.transform.tag == "Enemy"
                && hitTarget == hitTarget.GetComponent<BoxCollider>())
                {
                    if (!target.isDeath)
                    {
                        target.TakePhsicalDamage(_damage);
                    }
                }
            }
            if (ps != null)
            {
                ps.gameObject.SetActive(true);
            }
        }

        public void StopAnimation()
        {
            _myAnimator.enabled = false;
            _myAnimator.enabled = true;
        }

    }
}
