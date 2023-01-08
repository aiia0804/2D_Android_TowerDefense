using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SlimeProject_StatusEventSystem
{
    /// <summary>
    /// StatusEventHandler 安裝在可被影响GAMEOBJECT 上
    /// </summary>
    public class StatusEventHandler : MonoBehaviour
    {
        private readonly Dictionary<ScriptableBuff, TimedBuff> _buffs = new Dictionary<ScriptableBuff, TimedBuff>();
        public bool underStatusHandler = false;

        public void StatusUnderProcess()
        {
            underStatusHandler = true;
        }

        void Update()
        {
            //OPTIONAL, return before updating each buff if game is paused
            //if (Game.isPaused)
            //    return;
            if (_buffs.Count == 0) { return; }
            foreach (var buff in _buffs.Values.ToList())
            {
                buff.Tick(Time.deltaTime);
                if (buff.IsFinished)
                {
                    _buffs.Remove(buff.Buff);
                    underStatusHandler = false;
                }
            }
        }

        public void AddStatusEvent(TimedBuff buff, float parameter)
        {
            if (_buffs.ContainsKey(buff.Buff))
            {
                _buffs[buff.Buff].Activate(parameter);
            }
            else
            {
                _buffs.Add(buff.Buff, buff);
                buff.Activate(parameter);
            }
        }
    }
}