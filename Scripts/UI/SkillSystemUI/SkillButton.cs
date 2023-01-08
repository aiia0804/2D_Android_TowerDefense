using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeProject_ClassificationSheet;
using UnityEngine.UI;
using Slimeproject_SkillSystem;


namespace SlimeProject_UI
{
    public class SkillButton : MonoBehaviour
    {
        public ElementType type;
        [SerializeField] Image fillBar;
        Color defaultColor;
        Color fadeColor;

        private Button _myButton;
        private SkillBase _mySkill;
        private SkillSchedule _skillSchedule;

        private void Awake()
        {
            InitializeSystem();
            ConnectToEnergySystem();
        }
        private void InitializeSystem()
        {
            _mySkill = GetComponentInChildren<SkillBase>();
            _skillSchedule = GetComponentInParent<SkillSchedule>();
            _myButton = GetComponent<Button>();
            SetUpImage();
        }
        private void OnEnable()
        {
            _skillSchedule.skillModeOff += SkillModeOff;
        }
        private void OnDisable()
        {
            _skillSchedule.skillModeOff -= SkillModeOff;
        }

        private void SetUpImage()
        {
            //fillBar = GetComponentInChildren<Image>();
            SetBarToDefault();
        }

        private void SetBarToDefault()
        {
            fillBar.fillAmount = 1;
            //defaultColor = fillBar.color;
            //fadeColor = fillBar.color;
            //fadeColor.a = 0.5f;
            //fillBar.color = fadeColor;
            _myButton.enabled = false;
        }

        public void AddToTheBar(float addAmount)
        {
            fillBar.fillAmount -= (addAmount / 100);

            if (fillBar.fillAmount <= 0)
            {
                _myButton.enabled = true;
                //fillBar.color = defaultColor;
            }
        }

        private void ConnectToEnergySystem()
        {
            GetComponentInParent<Skill_Enery_Charging>().SetUpTheButton(type, this);
        }

        // Call by button to start Skill
        public void test()
        {
            _mySkill.StartSkill();
        }

        private void SkillModeOff()
        {
            if (_skillSchedule.currentSkill == _mySkill)
            {
                if (!debugMode)
                {
                    SetBarToDefault();
                }
            }
        }

        [SerializeField] bool debugMode = false;
        public void DebugModeSwitch()
        {
            if (!debugMode)
            {
                AddToTheBar(100);
            }
            debugMode = !debugMode;
        }



    }
}