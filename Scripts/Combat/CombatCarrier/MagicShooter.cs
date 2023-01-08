using UnityEngine;
using SlimeProject_Combat;

public class MagicShooter : CarrierBase
{
    [SerializeField] Transform shootPos;
    //Call by animation
    public override void Attack()
    {
        var proj = Instantiate(projectile, shootPos.position, Quaternion.identity);
        proj.GetComponent<FollowTypeProjec>().SetUp(_target, _damage, _targetLayer);
    }
}