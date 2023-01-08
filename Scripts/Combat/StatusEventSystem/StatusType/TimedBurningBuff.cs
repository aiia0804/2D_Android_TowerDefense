using System.Collections;
using System.Collections.Generic;
using SlimeProject_ClassificationSheet;
using SlimeProject_Combat;
using UnityEngine;


namespace SlimeProject_StatusEventSystem
{
    public class TimedBurningDebuff : TimedBuff
    {
        private readonly Health _health;

        public TimedBurningDebuff(ScriptableBuff buff, GameObject obj) : base(buff, obj)
        {
            _health = obj.GetComponent<Health>();
        }

        protected override void ApplyEffect(float parameter)
        {
            //Add damage to target
            ScriptableBurningDebuff burningBuff = (ScriptableBurningDebuff)Buff;
            float damage = _health.GetCurrentHP() * (burningBuff.statusDamageCoefficient / 100);
            _health.TakeElementDamage(damage, burningBuff.elementType);

        }

        public override void End()
        {
            //Stop burning
            EffectStacks = 0;
        }

    }
}