using UnityEngine;
using SlimeProject_UI;
using UnityEngine.EventSystems;
using SlimeProject_ClassificationSheet;
using SlimeProject_GridSystem;
using SlimeProject_UnitGeneratorSystem;
using Slimeproject_SkillSystem;

namespace SlimeProject_TouchControl
{
    public class TouchControl : MonoBehaviour
    {
        public LayerMask depolyModeLayer;
        public LayerMask skillModeLayer;
        private LayerMask _currentLayer;

        [SerializeField] Battle_UI_Control battle_UI_Control;
        [SerializeField] private SkillSchedule skillScheduler;

        //暫存
        private Vector2 _touchWorldPos;
        private PlayerUnit_Depolyer _slime_Depolyer;

        //Conditions
        private bool _deployMode = false;
        [SerializeField] private bool _skillMode = false;

        private void Awake()
        {
            _slime_Depolyer = GetComponentInChildren<PlayerUnit_Depolyer>();
        }

        private void OnEnable()
        {
            battle_UI_Control.onLoadModeOn += DepolyModeOn;
            battle_UI_Control.onLoadModeOff += DepolyModeOff;
            skillScheduler.skillModeOn += SkillModeOn;
            skillScheduler.skillModeOff += SkillModeOff;
        }

        private void OnDisable()
        {
            battle_UI_Control.onLoadModeOn -= DepolyModeOn;
            battle_UI_Control.onLoadModeOff -= DepolyModeOff;
            skillScheduler.skillModeOn -= SkillModeOn;
            skillScheduler.skillModeOff -= SkillModeOff;
        }

        #region modeOn
        private void DepolyModeOn()
        {
            _currentLayer = depolyModeLayer;
            _deployMode = true;
            _skillMode = false;
        }

        private void DepolyModeOff()
        {
            _deployMode = false;
        }
        private void SkillModeOn()
        {
            if (skillScheduler.currentSkill.data.skillType == SkillType.golbalType) { return; }
            _currentLayer = skillModeLayer;
            _deployMode = false;
            _skillMode = true;
        }

        private void SkillModeOff()
        {
            _skillMode = false;
        }
        private void FixedUpdate()
        {
            HandleTouch();
        }
        #endregion

        private void HandleTouch()
        {
            for (int i = 0; i < Input.touchCount; i++) //多指觸控
            {
                _touchWorldPos = Camera.main.ScreenToWorldPoint(Input.touches[i].position);

                RaycastHit hit;
                Physics.Raycast(Camera.main.ScreenPointToRay(Input.touches[i].position), out hit, Mathf.Infinity, _currentLayer);

                if (Input.touchCount > 0 && (Input.touches[i].phase == TouchPhase.Moved || Input.touches[i].phase == TouchPhase.Began))
                {
                    if (hit.transform == null || EventSystem.current.IsPointerOverGameObject(Input.touches[i].fingerId))
                    {
                        return;
                    }
                    if (_deployMode)
                    {
                        if (hit.transform.tag == "RowGrid")
                        {
                            SlimeProject_GridSystem.Grid rowGrid = hit.transform.GetComponent<SlimeProject_GridSystem.Grid>();
                            _slime_Depolyer.StartToDepoly(rowGrid);
                        }
                    }

                    if (_skillMode)
                    {
                        if (hit.transform.tag == "Land")
                        {
                            skillScheduler.ProcessSkill(_touchWorldPos, null);
                        }
                        else
                        {
                            skillScheduler.ProcessSkill(hit.transform.position, hit.transform.gameObject);
                        }

                    }
                    //TODO 做出 顯示Unit 資訊 TOUCH
                }
            }
        }

        public void ResetTheMode()
        {
            _skillMode = false;
            _deployMode = false;
        }
    }
}