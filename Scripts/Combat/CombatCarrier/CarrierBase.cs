using System;
using UnityEngine;
using SlimeProject_ClassificationSheet;
namespace SlimeProject_Combat
{
    public abstract class CarrierBase : MonoBehaviour
    {
        internal Animator _myAnimator;
        internal GameObject _target;
        internal float _damage;
        internal Health _heatlh;
        internal UnitType _unitType;
        internal float _raidous;
        internal GameObject projectile = null;
        internal string _targetLayer;

        private void Awake()
        {
            _myAnimator = GetComponent<Animator>();
            _heatlh = GetComponentInParent<Health>();
        }

        public void ProcessToAttack(GameObject target, float damage)
        {
            this._target = target;
            this._damage = damage;
            StartAnimation();
        }
        public void ProcessToAttack(GameObject target, float damage, GameObject projectile, UnitType unitType)
        {
            this._target = target;
            this._damage = damage;
            this.projectile = projectile;
            this._unitType = unitType;
            StartAnimation();
        }
        public void ProcessToAttack(GameObject target, float damage, GameObject projectile, string targetLayer)
        {
            this._target = target;
            this._damage = damage;
            this.projectile = projectile;
            this._targetLayer = targetLayer;
            StartAnimation();
        }
        public void ProcessToAttack(float damage, float radious)
        {
            this._damage = damage;
            this._raidous = radious;
            StartAnimation();
        }

        private void StartAnimation()
        {
            if (_target == null) { return; }
            try
            {
                if (_heatlh.isDeath || _target.GetComponent<Health>().isDeath) { return; }
            }
            catch
            {
                if (LayerMask.LayerToName(_target.layer) != _targetLayer) { return; }
            }
            _myAnimator.SetTrigger("Attack");
        }


        public virtual void ProcessToStop()
        {
            _myAnimator.SetTrigger("NotAbleAttack");
        }

        public abstract void Attack(); // call by animation
    }
}