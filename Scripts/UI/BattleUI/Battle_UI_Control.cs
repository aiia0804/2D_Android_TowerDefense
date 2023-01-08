using UnityEngine;
using System;
using SlimeProject_TouchControl;
using SlimeProject_PlayerUnitManager;
using SlimeProject_UnitGeneratorSystem;

namespace SlimeProject_UI
{
    public class Battle_UI_Control : MonoBehaviour
    {
        // 以後可以改成顯示UNIT INFO
        //[SerializeField] Transform battleUI;

        private PlayerUnit_Depolyer _playerUnit_Depolyer;
        private GameObject _currentButton;
        [SerializeField] Transform cancelButton;

        public event Action onLoadModeOn;
        public event Action onLoadModeOff;

        private PlayerUnitManager _playerUnitManager;
        private TouchControl _touchControl;

        private void Awake()
        {
            _playerUnitManager = FindObjectOfType<PlayerUnitManager>();
            _touchControl = GetComponent<TouchControl>();
            _playerUnit_Depolyer = GetComponentInChildren<PlayerUnit_Depolyer>();
        }
        private void OnEnable()
        {
            _playerUnit_Depolyer.deployCompleted += DisplayCompleted;
        }
        private void OnDisable()
        {
            _playerUnit_Depolyer.deployCompleted -= DisplayCompleted;
        }

        public void OnLoadeModeON(PlayerUnitType type, GameObject button)
        {
            _playerUnitManager.SetUpOnloadType(type);
            cancelButton.gameObject.SetActive(true);
            _currentButton = button;
            onLoadModeOn?.Invoke();
        }
        private void DisplayCompleted()
        {
            Destroy(_currentButton);
            DisplayFinsihed();
        }

        //Also call when cancel button pressed
        public void DisplayFinsihed()
        {
            onLoadModeOff?.Invoke();
            cancelButton.gameObject.SetActive(false);
        }
    }
}