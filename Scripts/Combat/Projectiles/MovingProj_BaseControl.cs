using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeProject_ClassificationSheet;

namespace SlimeProject_Combat
{
    public abstract class MovingProj_BaseControl : MonoBehaviour
    {
        [SerializeField] float flyingSpeed;
        public float destroyTime;
        // the layer for player. only trigger by enemy
        [SerializeField] LayerMask playerLayer;
        // the laye for Ai. only trigger by player
        [SerializeField] LayerMask aILayer;
        public ElementType elementType;

        internal float damage;
        internal DamageType projectileType;
        internal Vector3 targetPos;
        public bool startToMove;
        internal LayerMask targetLayer;
        internal UnitType inputType;



        //Cache
        Rigidbody myRigidbody;
        Vector3 flyingDirection;

        private void Start()
        {
            myRigidbody = GetComponent<Rigidbody>();
            SetUpType();
        }

        private void SetUpType()
        {
            if (elementType == ElementType.NoType)
            {
                projectileType = DamageType.physicDamage;
            }
            else
            {
                projectileType = DamageType.elementDamage;
            }
        }

        public void SetUpTarget(float damage, Vector3 target, UnitType inputType)
        {
            this.damage = damage;
            AdjustDirction(target);
            targetPos = target;
            this.inputType = inputType;
            EffectByEach();
            if (inputType == UnitType.Player)
            {
                targetLayer = playerLayer;
            }
            else
            {
                targetLayer = aILayer;
            }
            startToMove = true;
        }

        private void AdjustDirction(Vector3 target)
        {
            flyingDirection = (target - this.transform.position).normalized;
            Vector3 dir = target - this.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        private void FixedUpdate()
        {
            if (!startToMove) { return; }
            PrjectilesMoving();
        }

        private void PrjectilesMoving()
        {
            transform.position += flyingDirection * Time.deltaTime * flyingSpeed;
        }

        public void DestroyThis()
        {
            Destroy(this.gameObject);
        }
        public virtual void EffectByEach() { }
    }
}