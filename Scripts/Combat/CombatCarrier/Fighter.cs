using UnityEngine;
using SlimeProject_PlayerUnit;


namespace SlimeProject_Combat
{
    public class Fighter : CarrierBase
    {
        public override void Attack()  // call bal animation
        {
            if (_target == null || _heatlh.isDeath) { return; }
            _target.GetComponent<Health>().TakePhsicalDamage(_damage);
        }
    }
}