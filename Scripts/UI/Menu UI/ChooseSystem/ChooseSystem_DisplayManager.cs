using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using SlimeProjemct_CardsManager;
using System;

namespace SlimeProject_UI
{
    public class ChooseSystem_DisplayManager : MonoBehaviour
    {
        [SerializeField] Image displayImage;
        [SerializeField] TextMeshProUGUI typeLabel;
        [SerializeField] TextMeshProUGUI descpritionLabel;
        private void Awake()
        {
            DisableDisplay();
        }
        private void OnEnable()
        {
            Cards_Manager.equippedListSwitch += DisableDisplay;
        }
        private void OnDisable()
        {
            Cards_Manager.equippedListSwitch -= DisableDisplay;
        }

        private void DisableDisplay()
        {
            displayImage.enabled = false;
            typeLabel.text = "";
            descpritionLabel.text = "";
        }


        public void SetUpDisplay(Sprite image, string type, string descprition)
        {
            displayImage.enabled = true;
            displayImage.sprite = image;
            typeLabel.text = type;
            descpritionLabel.text = descprition;
        }

    }
}