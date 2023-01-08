using UnityEngine;
using SlimeProject_ClassificationSheet;
using SlimeProject_TouchControl;
using SlimeProject_PlayerUnitManager;
using SlimeProject_Combat;
using TMPro;

namespace SlimeProject_UI
{
    public class PlayerUnitButton_Button : MonoBehaviour
    {
        //Debug Purpose serializfield
        [SerializeField] int rescouresSpend;

        // Objects
        [SerializeField] PlayerUnitButton_Image icon;

        // 暫時保存COST TAG 可以在跟能量系統? 結合
        [SerializeField] TextMeshProUGUI costTag;
        [SerializeField] Transform cover;
        private PlayerUnitType elementType;

        public void SetUp(PlayerUnitType type, Sprite image, int spend)
        {
            PlayerUnitButton_Image icon = GetComponentInChildren<PlayerUnitButton_Image>();
            costTag.text = spend.ToString();
            icon.SetItem(image);
            elementType = type;
        }

        public void CurrentButton()
        {
            GetComponentInParent<Battle_UI_Control>().OnLoadeModeON(elementType, this.gameObject);
        }

        //Resource Update 暫時保存, 可以在跟能量系統? 結合

        // public void ResourcesUpdate()
        // {
        //     if (Resources_Manager.Instance.resources >= rescouresSpend)
        //     {
        //         cover.gameObject.SetActive(false);
        //     }
        //     else
        //     {
        //         cover.gameObject.SetActive(true);
        //     }
        // }

    }
}