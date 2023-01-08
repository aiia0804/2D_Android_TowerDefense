using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeProject_PlayerUnitManager;
using SlimeProject_ClassificationSheet;

namespace SlimeProject_UI
{

    public class SkillButton_Manager : MonoBehaviour
    {
        [SerializeField] GameObject[] buttonBoxPrefab;
        [SerializeField] List<ElementType> elementTypeList = new List<ElementType>(); //Dedbug Purpose Serializfield
        private Dictionary<ElementType, GameObject> d_allButton = new Dictionary<ElementType, GameObject>();

        private PlayerUnitManager _playerUnitManager;

        private void Start()
        {
            _playerUnitManager = FindObjectOfType<PlayerUnitManager>();
            SetUpButtonList();
            SetUp();
        }

        private void SetUpButtonList()
        {
            foreach (var button in buttonBoxPrefab)
            {
                d_allButton[button.GetComponent<SkillButton>().type] = button;
            }
        }


        private void SetUp()
        {
            foreach (Transform box in transform)
            {
                Destroy(box.gameObject);
            }

            //TODO 這裡要修改跟技能系統連接, 而常與SLIME_MANAGER
            IEnumerable<ElementType> type = _playerUnitManager.GetEquipedElementList();
            foreach (var i in type)
            {
                if (elementTypeList.Contains(i)) { continue; }
                var buttBox = Instantiate(d_allButton[i], transform);

            }
        }
    }
}