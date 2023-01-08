using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeProjemct_CardsManager;

namespace SlimeProject_UI
{
    public class ChooseSystem_EquipButtonManager : MonoBehaviour
    {
        private Cards_Manager _cardsManager;

        private void Awake()
        {
            _cardsManager = FindObjectOfType<Cards_Manager>();
        }
        // Call by the Button from UI
        public void Equip()
        {
            if (_cardsManager.currentCard == null) { return; }
            _cardsManager.EquippedToTheList();
        }

        public void Remove()
        {
            if (_cardsManager.currentCard == null) { return; }
            _cardsManager.RemoveFromTheList();
        }
    }
}