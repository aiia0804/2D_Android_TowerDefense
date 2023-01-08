using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SlimeProject_PlayerUnit;
using SlimeProject_ClassificationSheet;
using SlimeProject_JobClass;
using SlimeProject_Combat;

namespace SlimeProject_AI
{
    public class AI_Attack : MonoBehaviour
    {
        //Debug purpose
        [SerializeField] bool _coroutineWorking = false;
        [SerializeField] List<GameObject> attackTargets = new List<GameObject>();


        //cache
        private AI_Base _AI;
        private IJobClass _iJobClass;
        private Health _health;

        public float additave = 0;
        [SerializeField] LayerMask[] targetLayer;

        //figure & status
        [SerializeField] private float _attackCD, _attackDamage;
        private ElementType _elementType;


        private void Awake()
        {
            _AI = GetComponent<AI_Base>();
            _iJobClass = GetComponent<IJobClass>();
            _health = GetComponent<Health>();
        }
        private void Start()
        {
            InitializeDataBase();
        }
        private void InitializeDataBase()
        {
            _attackDamage = _AI.dataBase.attackDamage;
            _attackCD = _AI.dataBase.attackCD;
            _elementType = _AI.dataBase.elementType;
        }
        private void OnTriggerEnter(Collider unit)
        {
            if (unit.gameObject.layer == LayerMask.NameToLayer("SlimeRange")) { return; }

            foreach (var layer in layerMask)
            {
                if (layer.value == Mathf.Pow(2, unit.gameObject.layer))
                {
                    if (_health.isDeath || attackTargets.Contains(unit.gameObject)) { return; }

                    if (unit.gameObject.tag == "Slime")
                    {
                        if (unit.GetComponentInParent<Health>().isDeath) { return; }
                        attackTargets.Add(unit.transform.parent.gameObject);
                    }
                    else
                    {
                        attackTargets.Add(unit.gameObject);
                    }
                    if (!_coroutineWorking)
                    {
                        _coroutineWorking = true;
                        StartCoroutine(AttackPrepare());
                    }
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (attackTargets.Contains(other.gameObject))
            {
                attackTargets.Remove(other.gameObject);
            }
        }
        float timer = 0;
        private IEnumerator AttackPrepare()
        {
            if (attackTargets.Count <= 0 || _health.isDeath)
            {
                StopAttackAction();
            }
            while (attackTargets.Count > 0)
            {
                if (_AI.isParalizing) { yield return new WaitUntil(() => !_AI.isParalizing); }
                _AI.ActionHandler(false, true);
                StartCoroutine(EstimateList());
                _iJobClass.AttackPrepare(attackTargets, _attackDamage + additave, _elementType, _AI.unitType, _AI.dataBase.damgeRadious);
                timer = 0;
                yield return new WaitForSeconds(_attackCD);
            }
        }

        private IEnumerator EstimateList()
        {
            while (attackTargets.Count > 0)
            {
                for (int i = 0; i < attackTargets.Count; i++)
                {
                    if (attackTargets[i] == null)
                    {
                        attackTargets.Remove(attackTargets[i]);
                        continue;
                    }
                    if (attackTargets[i].tag == "Slime")
                    {
                        var enemy = attackTargets[i].GetComponent<Health>();
                        if (enemy.isDeath)
                        {
                            attackTargets.Remove(attackTargets[i]);
                            continue;
                        }
                    }
                    if (attackTargets.Count <= 0)
                    {
                        StopAttackAction();
                    }
                }
                yield return new WaitForEndOfFrame();
            }
            StopAttackAction();
        }

        private void StopAttackAction()
        {
            StopAllCoroutines();
            _coroutineWorking = false;
            _iJobClass.StopAttack();
            if (!_AI.isDeath)
            {
                _AI.ActionHandler(true, false);
            }
        }
    }
}
