using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeProject_SlimeDataBase;
using System;

namespace SlimeProject_FieldGuideManager
{
    /// 圖鑑系統, 管理所有可用
    /// Congrol all the usable cards
    /// Todo- conect with save system, and record the useable cards
    public class FieldGuideManager : MonoBehaviour
    {
        [SerializeField] CardConditions[] AllCards;
        public List<CardConditions> ableToUseCards = new List<CardConditions>();

        private void Awake()
        {
            SetUpAbleToUseList();
        }
        /// <summary>
        /// 所以可使用的CARD, 在可選擇裡顯示 
        /// </summary>
        private void SetUpAbleToUseList()
        {
            foreach (var card in AllCards)
            {
                if (card.ableToUse)
                {
                    ableToUseCards.Add(card);
                }
            }
        }
        /// <summary>
        /// 拿取所有可用CARDS
        /// </summary>
        /// <returns> 可用CARDS</returns>
        public IEnumerable<PlayerUnit_DataBase> GetAvilableCards()
        {
            for (int i = 0; i < ableToUseCards.Count; i++)
            {
                yield return ableToUseCards[i].plyaerUnit;
            }
        }
    }

    [System.Serializable]
    public class CardConditions
    {
        public PlayerUnit_DataBase plyaerUnit;
        public bool ableToUse;
    }


}