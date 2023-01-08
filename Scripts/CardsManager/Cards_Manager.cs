using UnityEngine;
using UnityEngine.SceneManagement;
using SlimeProject_PlayerUnit_DataBase;
using SlimeProject_PlayerUnitManager;
using SlimeProject_FieldGuideManager;
using System.Collections.Generic;
using System;

namespace SlimeProjemct_CardsManager
{
    public class Cards_Manager : MonoBehaviour
    {
        //DebugPurpose
        public PlayerUnit_DataBase currentCard;
        [SerializeField] List<PlayerUnit_DataBase> chooseCards;
        [SerializeField] int maximumCard;
        [SerializeField] bool includeInTheList;

        public static event Action reachTheMaxEquipped;
        public static event Action equippedListSwitch;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void SetCurrentCard(PlayerUnit_DataBase currentCard)
        {
            includeInTheList = false;

            if (chooseCards.Contains(currentCard))
            {
                this.currentCard = currentCard;
                includeInTheList = true;
            }
            else
            {
                this.currentCard = currentCard;
            }
        }
        public void EquippedToTheList()
        {

            if (chooseCards.Count == maximumCard)
            {
                reachTheMaxEquipped?.Invoke();
                return;
            }
            if (chooseCards.Contains(currentCard)) { return; }

            chooseCards.Add(currentCard);
            equippedListSwitch?.Invoke();
            ReseatCurrentCard();

        }
        public void RemoveFromTheList()
        {
            if (currentCard == null || !includeInTheList) { return; }

            int indexToRemove = -1;
            foreach (var card in chooseCards)
            {
                indexToRemove++;
                if (card == currentCard)
                {
                    break;
                }
            }
            if (indexToRemove >= -1)
            {
                chooseCards.RemoveAt(indexToRemove);
                equippedListSwitch?.Invoke();
                ReseatCurrentCard();

            }
        }
        private void ReseatCurrentCard()
        {
            currentCard = null;
        }

        public PlayerUnit_DataBase[] GetChoosenCards()
        {
            return chooseCards.ToArray();
        }
    }
}
