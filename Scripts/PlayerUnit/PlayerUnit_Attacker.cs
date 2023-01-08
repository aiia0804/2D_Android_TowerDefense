using System.Collections.Generic;
using System.Collections;
using SlimeProject_Combat;
using UnityEngine;
using SlimeProject_JobClass;
using Slimeproject_ActionScheduler;
using System;
using SlimeProject_ClassificationSheet;

namespace SlimeProject_PlayerUnit
{
    public class PlayerUnit_Attacker : MonoBehaviour
    {
        [SerializeField] private List<GameObject> attackTargets = new List<GameObject>();
        public float additave = 0;

        //Cache
        private PlayerUnit_Base _unit;
        private Health _health;

        private bool _attackAble = true;
        private float _attackCD, _attackDamage;
        private ElementType _elementType;
        private SphereCollider _sphereColider;
        private BoxCollider _unitBody;

        private void Awake()
        {
            _unit = GetComponent<PlayerUnit_Base>();
            _health = GetComponent<Health>();
            _sphereColider = GetComponent<SphereCollider>();
            _unitBody = GetComponentInChildren<BoxCollider>();
        }
        private void Start()
        {
            InitializeDataBase();
        }

        private void InitializeDataBase()
        {
            _attackDamage = _unit.conditions.attackDamage;
            _attackCD = _unit.conditions.attacdCD;
            _elementType = _unit.conditions.elementType;
        }

        private void OnTriggerEnter(Collider unit)
        {
            if (unit.gameObject.layer == LayerMask.NameToLayer("EnemyRange")) { return; }

            if (unit.tag == "Enemy")
            {
                if (_health.isDeath
                || attackTargets.Contains(unit.gameObject)
                || unit.GetComponentInParent<Health>().isDeath) { return; }

                attackTargets.Add(unit.transform.parent.gameObject);
                StartCoroutine(AttackPrepare());
                _move.MoveSwitch(false);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (attackTargets.Contains(other.gameObject))
            {
                attackTargets.Remove(other.gameObject);
            }
        }

        private IEnumerator AttackPrepare()
        {
            if (attackTargets.Count <= 0 || !_attackAble)
            {
                yield break;
            }
            while (attackTargets.Count > 0)
            {
                for (int i = 0; i < attackTargets.Count; i++)
                {
                    if (attackTargets[i] == null || TargetTooFar(attackTargets[i]))
                    {
                        attackTargets.RemoveAt(i);
                        continue;
                    }
                }
                GetComponent<IJobClass>().AttackPrepare(attackTargets,
                                                        _attackDamage + additave,
                                                        _unit.conditions.elementType,
                                                        _unit.unitType,
                                                        _unit.conditions.damageRadious);
                StartCoroutine(EstimateList());
                yield return new WaitForSeconds(_attackCD);
            }
        }

        private bool TargetTooFar(GameObject target)
        {
            var targetBox = target.GetComponentInChildren<BoxCollider>();
            var boxDelta = (targetBox.size.x + targetBox.size.y) / 2;
            var distance2Target = Vector2.Distance(this.transform.position, target.transform.position) - boxDelta;

            if (distance2Target > _sphereColider.radius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private IEnumerator EstimateList()
        {
            while (attackTargets.Count > 0)
            {
                for (int i = 0; i < attackTargets.Count; i++)
                {
                    attackTargets[i].TryGetComponent<Health>(out Health enemy);
                    if (enemy.isDeath)
                    {
                        attackTargets.Remove(attackTargets[i]);
                        continue;
                    }
                    yield return new WaitForSeconds(Time.deltaTime);
                }
            }
            StopAttackAction();
        }

        public void StopAttackAction()
        {
            GetComponent<IJobClass>().StopAttack();
            StopAllCoroutines();
            _move.MoveSwitch(true);
        }
    }
}