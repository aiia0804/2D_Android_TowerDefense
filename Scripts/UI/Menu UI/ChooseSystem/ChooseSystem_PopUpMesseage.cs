using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeProjemct_CardsManager;


namespace SlimeProject_UI
{
    public class ChooseSystem_PopUpMesseage : MonoBehaviour
    {
        [SerializeField] Transform overEquippedPopUp;

        private void OnEnable()
        {
            Cards_Manager.reachTheMaxEquipped += OverEquipped;
        }

        private void OnDisable()
        {
            Cards_Manager.reachTheMaxEquipped -= OverEquipped;
        }

        public void OverEquipped()
        {
            overEquippedPopUp.gameObject.SetActive(true);
        }
    }
}