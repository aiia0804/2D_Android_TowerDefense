using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeProject_UnitGeneratorSystem;
using TMPro;
using SlimeProject_BattleTimer;


namespace SlimeProject_UI
{
    public class WaveDisplay : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI waveDisplay;
        private WaveManager _waveManager;
        private int _totalUnit;
        private int _generatedUnit = 0;
        private void Awake()
        {
            _waveManager = FindObjectOfType<WaveManager>();
        }

        private void OnEnable()
        {
            Battle_Timer.timeUp += UpdateDisplay;
        }
        private void OnDisable()
        {
            Battle_Timer.timeUp -= UpdateDisplay;
        }
        private void Start()
        {
            _totalUnit = _waveManager.totalWave;
            waveDisplay.text = $"0/{_totalUnit}";
        }

        private void UpdateDisplay()
        {
            Invoke(nameof(CheckAndUpdated), 1f);
        }
        private void CheckAndUpdated()
        {
            _generatedUnit = _waveManager.generatedQty;
            waveDisplay.text = $"{_generatedUnit}/{_totalUnit}";
        }

    }
}