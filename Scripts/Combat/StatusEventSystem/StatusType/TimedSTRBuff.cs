using SlimeProject_Combat;
using SlimeProject_AI;
using SlimeProject_PlayerUnit;
using UnityEngine;

namespace SlimeProject_StatusEventSystem
{

    public class TimedSTRBuff : TimedBuff
    {
        private GameObject _target;
        private float _originalFigure;
        private bool targetIsAi = false;

        public TimedSTRBuff(ScriptableBuff buff, GameObject obj) : base(buff, obj)
        {
            _target = obj;
        }
        public override void End()
        {
            if (!targetIsAi)
            {
                PlayerUnit_Attacker playerUnit = _target.GetComponent<PlayerUnit_Attacker>();
                playerUnit.additave = _originalFigure;
            }
            else
            {
                var enemy = _target.GetComponent<AI_Attack>();
                enemy.additave = _originalFigure;
            }
        }
        /// <summary>
        /// the status will add str to the unit
        /// </summary>
        /// <param name="parameter"> the amount of str up points </param>
        protected override void ApplyEffect(float parameter)
        {
            _target.TryGetComponent<PlayerUnit_Attacker>(out PlayerUnit_Attacker playerUnit_Attacker);
            if (playerUnit_Attacker)
            {
                _originalFigure = playerUnit_Attacker.additave;
                playerUnit_Attacker.additave += parameter;
            }
            else
            {
                var enemy = _target.GetComponent<AI_Attack>();
                _originalFigure = enemy.additave;
                enemy.additave += parameter;
                targetIsAi = true;
            }

        }
    }
}