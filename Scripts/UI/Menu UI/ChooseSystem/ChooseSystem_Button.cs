using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SlimeProject_SlimeDataBase;
using SlimeProjemct_CardsManager;
using UnityEngine.UI;
using System;

namespace SlimeProject_UI
{
    public class ChooseSystem_Button : MonoBehaviour
    {
        // Objects
        [SerializeField] ChooseSystem_Image icon;
        [SerializeField] TextMeshProUGUI equipedTag;
        [SerializeField] Transform cover;

        private Cards_Manager _cardManager;
        private ChooseSystem_DisplayManager _displayManager;


        //debugpurpose
        [SerializeField] PlayerUnit_DataBase slimeType;

        public void SetUp(PlayerUnit_DataBase type, Cards_Manager cards_Manager, ChooseSystem_DisplayManager displayManager)
        {
            slimeType = type;
            ChooseSystem_Image icon = GetComponentInChildren<ChooseSystem_Image>();
            icon.SetItem(slimeType.depolyConditions.image);
            _cardManager = cards_Manager;
            _displayManager = displayManager;
        }

        //Call by Button from the UI
        public void CurrentButton()
        {
            _cardManager.SetCurrentCard(slimeType);
            SetUpDisplay();
        }

        private void SetUpDisplay()
        {
            _displayManager.SetUpDisplay
            (
                slimeType.depolyConditions.image,
                slimeType.slimeType.ToString(),
                slimeType.depolyConditions.description
            );

        }

        public void CardEquippedSwitch()
        {
            equipedTag.gameObject.SetActive(!equipedTag.gameObject.activeSelf);
            cover.gameObject.SetActive(!cover.gameObject.activeSelf);
        }
    }
}