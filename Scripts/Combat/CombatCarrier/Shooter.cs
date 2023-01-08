using UnityEngine;
using SlimeProject_ClassificationSheet;
namespace SlimeProject_Combat
{
    public class Shooter : CarrierBase
    {
        [SerializeField] Transform firePosition;

        // Call by animation
        public override void Attack()
        {
            if (_target == null || _heatlh.isDeath) { return; }
            var proj = Instantiate(projectile, firePosition.position, Quaternion.identity).GetComponent<MovingProj_BaseControl>(); ;
            proj.SetUpTarget(_damage, _target.transform.position, _unitType);
            ProcessToStop();
        }
    }
}