using TMPro;
using UnityEngine;
using System.Collections;
using Slimeproject_SkillSystem;

namespace SlimeProject_UI
{
    public class SkillDescDisplay : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI skillNameLabel;
        [SerializeField] TextMeshProUGUI skillDescLabel;
        [SerializeField] GameObject displayBar;
        [SerializeField] float defaultHeight;

        private RectTransform _displayBarRect;
        private Vector3 _startPos;
        private Vector3 _hidePos;
        private SkillSchedule _skillSchedule;
        private bool _disappear = false;
        private bool _display = false;

        private void Awake()
        {
            _skillSchedule = GetComponentInParent<SkillSchedule>();
            _startPos = GetComponent<RectTransform>().position;
            _hidePos = new Vector3(_startPos.x, _startPos.y + defaultHeight, _startPos.z);
            _displayBarRect = displayBar.GetComponent<RectTransform>();
            _displayBarRect.position = _hidePos;
        }
        private void OnEnable()
        {
            _skillSchedule.skillModeOn += SkillModeOn;
            _skillSchedule.skillModeOff += SkillModeOff;
        }
        private void OnDisable()
        {
            _skillSchedule.skillModeOn -= SkillModeOn;
            _skillSchedule.skillModeOff -= SkillModeOff;
        }

        private void SkillModeOn()
        {
            if (_skillSchedule.currentSkill != null)
            {
                skillNameLabel.text = _skillSchedule.currentSkill.data.name;
                skillDescLabel.text = _skillSchedule.currentSkill.data.skillDescr;
                displayBar.SetActive(true);
                StopCoroutine(Disapear());
                _disappear = false;
                _display = true;
                StartCoroutine(Display());
            }

        }
        private void SkillModeOff()
        {
            StopCoroutine(Display());
            _display = false;
            _disappear = true;
            StartCoroutine(Disapear());
        }

        private IEnumerator Display()
        {
            while (Vector3.Distance(_displayBarRect.position, _startPos) > .5f)
            {
                if (!_display) { yield break; }
                _displayBarRect.position = Vector3.Lerp(_displayBarRect.position, _startPos, 0.2f);
                yield return new WaitForEndOfFrame();
            }
        }

        private IEnumerator Disapear()
        {
            while (Vector3.Distance(_displayBarRect.position, _hidePos) > .5f)
            {
                if (!_disappear) { yield break; }
                _displayBarRect.position = Vector3.Lerp(_displayBarRect.position, _hidePos, 0.2f);
                yield return new WaitForEndOfFrame();
            }
            displayBar.SetActive(false);
        }


    }
}