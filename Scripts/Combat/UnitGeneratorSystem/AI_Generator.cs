using UnityEngine;
using System.Collections.Generic;
using SlimeProject_BattleTimer;
using SlimeProject_GridSystem;
using SlimeProject_AI;
using SlimeProject_AIDataBase;

namespace SlimeProject_UnitGeneratorSystem
{

    public class AI_Generator : MonoBehaviour
    {
        public LineConfiguration configuration;
        [SerializeField] Transform genateorPoint;

        //累積生成怪物點數
        int accumulateMBPoints = 0;
        //累積死亡怪物點數
        [SerializeField] int currentMove = 0;
        private RowGridSystem _row;
        private WaveManager _wManager;
        private Transform _AIPool;
        private int _condtionToStart;
        private List<int> avilableUnitID = new List<int>();
        private bool _secondStage = false;


        private void OnEnable()
        {
            Battle_Timer.timeUp += TimeTrigger;
        }
        private void OnDisable()
        {
            Battle_Timer.timeUp -= TimeTrigger;
        }
        private void Start()
        {
            InitializeFigure();
        }

        private void InitializeFigure()
        {
            currentMove = configuration.CDTime;
            _row = GetComponent<RowGridSystem>();
            _wManager = GetComponentInParent<WaveManager>();
            _AIPool = _wManager.AIUnitPool;
            _condtionToStart = configuration.condtionToStartGenerate;
            BuildTheIDList();
        }

        private void BuildTheIDList()
        {
            if (configuration.speicalID.Length == 0)
            {
                foreach (var id in configuration.AI_ID)
                {
                    avilableUnitID.Add(id);
                }
            }
            else
            {
                List<int> temporary = new List<int>();
                foreach (var specialID in configuration.speicalID)
                {
                    temporary.Add(specialID);
                }
                foreach (var id in configuration.AI_ID)
                {
                    if (!temporary.Contains(id) && !avilableUnitID.Contains(id))
                    {
                        avilableUnitID.Add(id);
                    }
                }
            }
        }
        private void TimeTrigger()
        {
            if (_wManager.generatedQty < _condtionToStart) { return; }
            if (accumulateMBPoints > configuration.conditionForSpecialIDGenerate && !_secondStage)
            {
                _secondStage = true;
                foreach (var specialID in configuration.speicalID)
                {
                    avilableUnitID.Add(specialID);
                }
            }
            currentMove -= 1;

            if (currentMove <= 0)
            {
                Generate();
                currentMove = configuration.CDTime;
            }
        }

        private void Generate()
        {
            if (accumulateMBPoints >= configuration.totalQty) { return; }

            for (int i = 0; i < configuration.qtyForOneWave; i++)
            {
                //Dice(); 隨機從ID中召喚出相對應點數的怪 -TODO待寫
                int diceNum = Random.Range(0, avilableUnitID.Count);
                AIDataBase dataBase = _wManager.GetTheDataBase(avilableUnitID[diceNum]);
                GameObject AI = Instantiate(dataBase.prefab);
                AI.transform.SetParent(_AIPool.transform);
                AI.transform.position = genateorPoint.position;
                AI.GetComponent<AI_Base>().SetUpData(dataBase, _row);
                accumulateMBPoints++;
                _wManager.UnitGenerated();
            }
        }


    }
}