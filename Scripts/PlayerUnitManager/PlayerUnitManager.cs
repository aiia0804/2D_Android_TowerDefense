using System.Collections.Generic;
using UnityEngine;
using SlimeProject_PlayerUnit_DataBase;
using SlimeProject_ClassificationSheet;
using SlimeProjemct_CardsManager;


namespace SlimeProject_PlayerUnitManager
{
    public class PlayerUnitManager : MonoBehaviour
    {
        [Header("Unit 相關")]
        [Tooltip("放Unit的DATABASE用")]
        [SerializeField] PlayerUnit_DataBase[] allUnitData;

        //管理Unit 與 DATRA連接DICTIONARY
        private static Dictionary<PlayerUnitType, PlayerUnit_DataBase> allUnit =
        new Dictionary<PlayerUnitType, SlimeProject_PlayerUnit_DataBase>();


        //當存ONLOAD Unit
        public PlayerUnitType onLoadType;
        public GameObject currentUnit;

        public void SetUpDataBases()
        {
            Cards_Manager cards_Manager = FindObjectOfType<Cards_Manager>();
            allUnitData = cards_Manager.GetChoosenCards();
        }

        public void SetUpOnloadType(PlayerUnitType type)
        {
            onLoadType = type;
        }
        public void SetUpCurrentUnit(GameObject currentUnit)
        {
            this.currentUnit = currentUnit;
        }
        private void Awake()
        {

            SetUpDataBases();
            BuildTheList();
        }

        private void BuildTheList()
        {
            for (int i = 0; i < allUnitData.Length; i++)
            {
                allUnit[allUnitData[i].unitType] = allUnitData[i];
            }
        }

        #region Handle Pool

        public void Destroy(GameObject unit)
        {
            Destroy(unit);
        }

        public GameObject Generate()
        {
            GameObject nextUnit = Instantiate(allUnit[onLoadType].unitPrefab);
            return nextUnit;
        }

        public IEnumerable<PlayerUnitType> GetEquipedUnitList()
        {
            foreach (var unit in allUnit)
            {
                yield return unit.Value.unitType;
            }
        }
        #endregion

        #region GetUnitData

        public Sprite GetUnitImage(PlayerUnitType type)
        {
            return allUnit[type].depolyConditions.image;
        }
        public int GetUnitSpendREscoures(PlayerUnitType type)
        {
            return allUnit[type].depolyConditions.resoucesSpend;
        }
        public SlimeProject_PlayerUnit_DataBase.PlayerUnitConditions GetUnitConditions(PlayerUnitType type)
        {
            return allUnit[type].PlayerUnitConditions;
        }

        #endregion
    }



}

