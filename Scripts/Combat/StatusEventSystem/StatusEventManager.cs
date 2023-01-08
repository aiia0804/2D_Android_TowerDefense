using System.Collections.Generic;
using UnityEngine;
using SlimeProject_ClassificationSheet;

namespace SlimeProject_StatusEventSystem
{
    public class StatusEventManager : MonoBehaviour
    {
        [SerializeField] private ScriptableBuff[] _allStatus;
        public Dictionary<StatusType, ScriptableBuff> allStatusList = new Dictionary<StatusType, ScriptableBuff>();
        private static StatusEventManager _instance;
        public static StatusEventManager Instance { get { return _instance; } }
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                if (_instance != this)
                {
                    Destroy(this.gameObject);
                }
            }
            InatliizeBuffList();
        }

        private void InatliizeBuffList()
        {
            foreach (var status in _allStatus)
            {
                allStatusList[status.statusType] = status;
            }
        }

        public ScriptableBuff GetStatusEvent(StatusType type)
        {
            return allStatusList[type];
        }
    }
}