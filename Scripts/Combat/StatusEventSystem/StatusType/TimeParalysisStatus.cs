using SlimeProject_Combat;
using SlimeProject_AI;
using SlimeProject_PlayerUnit;
using UnityEngine;

namespace SlimeProject_StatusEventSystem
{

    public class TimeParalysisStatus : TimedBuff
    {
        private GameObject _target;
        private bool _activated = false;
        public TimeParalysisStatus(ScriptableBuff buff, GameObject obj) : base(buff, obj)
        {
            _target = obj;
        }

        public override void End()
        {
            _target.TryGetComponent<AI_Base>(out AI_Base AI);
            if (AI)
            {
                // AI get paralysis effect
                AI.SetUpParalyzing(false);
                _activated = false;
            }
            else
            {
                // PlayerUnit paralysis effect. -TODO Make it

            }
            EffectStacks = 0;
        }

        protected override void ApplyEffect(float parameter)
        {
            _target.TryGetComponent<AI_Base>(out AI_Base ai);
            if (ai && !_activated)
            {
                // AI get paralysis effect
                ai.SetUpParalyzing(true);
                _activated = true;
            }
            else
            {
                // PlayerUnit paralysis effect. -TODO Make it

            }
        }
    }
}