using UnityEngine;
using System;
using SlimeProject_ClassificationSheet;
using SlimeProject_CombatElement;



namespace SlimeProject_Combat
{
    public class Health : MonoBehaviour
    {
        [Header("從DATABASE抓資料出來")]
        [SerializeField] float health; //Debug Purpose Serializfield
        [SerializeField] float defense;
        [SerializeField] ElementType type;
        [SerializeField] float damageCD = 0.5f;
        public Animator myAnimator;
        public bool isDeath = false;
        public event Action UnitOnDie;

        private void Awake()
        {
            myAnimator = GetComponentInChildren<Animator>();
        }
        private void OnEnable()
        {
            isDeath = false;
        }

        public void SetUpData(float hpPoints, ElementType type, float defense)
        {
            health = hpPoints;
            this.type = type;
            this.defense = defense;
        }
        public float GetCurrentHP()
        {
            return health;
        }
        public void TakeElementDamage(float damage, ElementType type)
        {
            float damageAfterCalucalte = CalucationElementDamage(damage, type);
            HandleDamage(damageAfterCalucalte);
        }
        public void TakePhsicalDamage(float damage)
        {
            float damageAfterCalucalte = CalcuationPyshicalDamage(damage);
            HandleDamage(damageAfterCalucalte);
        }

        public void HandleDamage(float damageAfterCalucalte)
        {
            if (isDeath) { return; }
            health -= damageAfterCalucalte;
            myAnimator.SetTrigger("Hurt");

            if (health <= 0)
            {
                ProcessDeath();
            }
        }

        public float CalucationElementDamage(float damage, ElementType attackerType)
        {
            float elementAdditive = ElementManager.Instance.DamageCalucation(type, attackerType);
            float calculatedDamage = damage * (elementAdditive / 100);
            return calculatedDamage;
        }

        private float CalcuationPyshicalDamage(float damage)
        {
            float calculatedDamage = damage * (damage / (damage + defense));
            return calculatedDamage;
        }

        private void ProcessDeath()
        {
            myAnimator.SetTrigger("Death");
            UnitOnDie?.Invoke();
            isDeath = true;
        }
    }
}