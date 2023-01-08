using UnityEngine;

namespace SlimeProject_StatusEventSystem
{
    public abstract class TimedBuff
    {

        protected float Duration;
        protected int EffectStacks;
        public ScriptableBuff Buff { get; }
        protected readonly GameObject Obj;
        public bool IsFinished;

        public TimedBuff(ScriptableBuff buff, GameObject obj)
        {
            Buff = buff;
            Obj = obj;
        }

        public void Tick(float delta)
        {
            Duration -= delta;
            if (Duration <= 0)
            {
                End();
                IsFinished = true;
            }
        }

        /**
         * Activates buff or extends duration if ScriptableBuff has IsDurationStacked or IsEffectStacked set to true.
         */
        public void Activate(float parameter)
        {
            if (Buff.IsEffectStacked || Duration <= 0)
            {
                ApplyEffect(parameter);
                EffectStacks++;
            }

            if (Buff.IsDurationStacked || Duration <= 0)
            {
                Duration += Buff.Duration;
            }
        }
        /// <summary>
        /// ther paramaeter for speific status event. Damge duration or others?
        /// Electric set to no use now.
        /// </summary>
        /// <param name="parameter"></param>
        protected abstract void ApplyEffect(float parameter);
        public abstract void End();
    }
}