using System.Collections;
using System.Collections.Generic;
using SlimeProject_ClassificationSheet;
using UnityEngine;
using SlimeProject_FieldGuideManager;
using SlimeProject_SlimeDataBase;
using SlimeProjemct_CardsManager;
using System;

namespace SlimeProject_UI
{
    public class ChooseSystem_ButtonManager : MonoBehaviour
    {
        [SerializeField] ChooseSystem_Button buttonBoxPrefab;
        [SerializeField] List<PlayerUnit_DataBase> unitTypeList = new List<PlayerUnit_DataBase>(); //Dedbug Purpose Serializfield
        [SerializeField] Dictionary<PlayerUnit_DataBase, ChooseSystem_Button> d_AllButton = new Dictionary<PlayerUnit_DataBase, ChooseSystem_Button>();
        [SerializeField] PlayerUnit_DataBase[] choosenCardLists;
        private Cards_Manager _cardManager;
        private FieldGuideManager _fieldGuideManager;
        private ChooseSystem_DisplayManager _diplayManager;

        private void Awake()
        {
            _fieldGuideManager = FindObjectOfType<FieldGuideManager>();
            _cardManager = FindObjectOfType<Cards_Manager>();
            _diplayManager = FindObjectOfType<ChooseSystem_DisplayManager>();
        }

        private void Start()
        {
            SetUpAllTypeList();
            SetUpChoosenCardList();
            SetUpDisplay();
        }

        private void SetUpChoosenCardList()
        {
            choosenCardLists = FindObjectOfType<Cards_Manager>().GetChoosenCards();
        }

        private void OnEnable()
        {
            Cards_Manager.equippedListSwitch += EquipdSwitch;
        }
        private void OnDisable()
        {
            Cards_Manager.equippedListSwitch -= EquipdSwitch;
        }

        private void SetUpAllTypeList()
        {
            IEnumerable<PlayerUnit_DataBase> type = _fieldGuideManager.GetAvilableCards();
            foreach (var i in type)
            {
                unitTypeList.Add(i);
            }
        }

        private void SetUpDisplay()
        {
            foreach (Transform box in transform)
            {
                Destroy(box.gameObject);
            }

            for (int i = 0; i < unitTypeList.Count; i++)
            {
                var buttonBox = Instantiate(buttonBoxPrefab, transform);
                d_AllButton[unitTypeList[i]] = buttonBox;
                buttonBox.SetUp(unitTypeList[i], _cardManager, _diplayManager);


                // To check whether the card are already in the list or not.
                foreach (var type in choosenCardLists)
                {
                    if (unitTypeList[i] == type)
                    {
                        buttonBox.CardEquippedSwitch();
                    }
                }
            }
        }

        public List<PlayerUnit_DataBase> GetBattleCards()
        {
            return unitTypeList;
        }

        public void EquipdSwitch()
        {
            d_AllButton[_cardManager.currentCard].CardEquippedSwitch();
        }
    }
}