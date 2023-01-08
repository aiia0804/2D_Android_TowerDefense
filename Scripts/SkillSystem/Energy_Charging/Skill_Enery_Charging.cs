using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeProject_ClassificationSheet;
using SlimeProject_UI;

namespace Slimeproject_SkillSystem
{
    public class Skill_Enery_Charging : MonoBehaviour
    {
        private SKillCharge_VFXSystem _vfxSystem;
        private Dictionary<ElementType, List<SkillButton>> buttons = new Dictionary<ElementType, List<SkillButton>>();
        [SerializeField] RectTransform canvsTransfomr;

        private void Awake()
        {
            _vfxSystem = FindObjectOfType<SKillCharge_VFXSystem>();
            if (buttons == null)
            {
                buttons = new Dictionary<ElementType, List<SkillButton>>();
            }
        }
        public void SetUpTheButton(ElementType type, SkillButton button)
        {
            if (!buttons.ContainsKey(type))
            {
                buttons[type] = new List<SkillButton>();
                buttons[type].Add(button);
            }
            else
            {
                buttons[type].Add(button);
            }
        }

        public void ChargeEnergy(ElementType type, float energy, Vector3 position)
        {
            foreach (var button in buttons[type])
            {
                button.AddToTheBar(energy);

                var rect = button.GetComponent<RectTransform>();

                Vector3 screenPos = Camera.main.WorldToScreenPoint(rect.position);
                Vector2 screenPos2D = new Vector2(screenPos.x, screenPos.y);
                Vector3 anchoredPos;
                RectTransformUtility.ScreenPointToWorldPointInRectangle(canvsTransfomr, screenPos2D, Camera.main, out anchoredPos);
                _vfxSystem.StartToMove(position, anchoredPos, type);
            }
        }
    }
}