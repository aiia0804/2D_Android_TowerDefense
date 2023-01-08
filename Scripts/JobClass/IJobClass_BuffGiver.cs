using System.Collections.Generic;
using SlimeProject_ClassificationSheet;
using UnityEngine;
using SlimeProject_Combat;
using SlimeProject_StatusEventSystem;
using Slimeproject_SkillSystem;


namespace SlimeProject_JobClass
{
    public class IJobClass_BuffGiver : MonoBehaviour, IJobClass
    {
        [SerializeField] StatusType statusType;
        [SerializeField] Sprite vfxSPrite;
        [SerializeField] LayerMask targetLayer;
        private float _radious;
        private BuffGiver _buffGiver;
        private float _damage;


        private void Awake()
        {
            _buffGiver = GetComponentInChildren<BuffGiver>();
        }
        private void OnEnable()
        {
            _buffGiver.animationFinished += Attack;
        }
        private void OnDisable()
        {
            _buffGiver.animationFinished -= Attack;
        }

        public void AttackPrepare(List<GameObject> targets, float damage, ElementType type, UnitType unitType, float radious)
        {
            if (targets.Count > 0)
            {
                _radious = radious;
                _damage = damage;
                _buffGiver.ProcessToAttack(targets[0].transform.parent.gameObject, 0);
            }
        }

        private void Attack()
        {
            Collider[] hitTargets = Physics.OverlapSphere(this.transform.position, _radious, targetLayer);
            foreach (Collider hitTarget in hitTargets)
            {
                if (hitTarget.transform.tag == this.transform.tag)
                {
                    if (hitTarget.transform.parent.gameObject == this.gameObject) { continue; }
                    var target = hitTarget.GetComponentInParent<Health>();
                    var statusHander = target.GetComponent<StatusEventHandler>();
                    if (!target.isDeath)
                    {
                        target.GetComponent<StatusEventHandler>().AddStatusEvent(StatusEventManager.Instance.
                         GetStatusEvent(statusType).InitializeStatusEvent(target.gameObject), _damage);
                        target.GetComponentInChildren<UnitStatusVFXHandler>().HandleVFX(vfxSPrite);
                    }
                }
            }
        }

        public void StopAttack()
        {
            _buffGiver.ProcessToStop();
        }
    }
}