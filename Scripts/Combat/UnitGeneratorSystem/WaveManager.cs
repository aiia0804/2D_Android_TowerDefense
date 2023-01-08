using UnityEngine;
using System.Collections.Generic;
using System;
using SlimeProject_AIDataBase;
using Slimeproject_SkillSystem;
using SlimeProject_GridSystem;


namespace SlimeProject_UnitGeneratorSystem
{
    public class WaveManager : MonoBehaviour
    {

        [SerializeField] AILists allAIData;
        [SerializeField] List<LineConfiguration> lineConfiguration = new List<LineConfiguration>();
        public Dictionary<int, AIDataBase> dropBox = new Dictionary<int, AIDataBase>();
        private AI_Generator[] genators;
        private RowGridSystem[] rows;
        public Transform AIUnitPool;
        private SkillSchedule _skillSchedule;
        public int totalWave { get; private set; }
        public int generatedQty { get; private set; }

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            genators = GetComponentsInChildren<AI_Generator>();
            rows = GetComponentsInChildren<RowGridSystem>();
            BuildTheList();
            _skillSchedule = GetComponentInParent<SkillSchedule>();
            _skillSchedule.UpdateAIList(AIUnitPool);
        }

        private void BuildTheList()
        {
            foreach (var genator in genators)
            {
                lineConfiguration.Add(genator.configuration);
            }

            foreach (var line in lineConfiguration)
            {
                //get All the wave
                totalWave += line.totalQty;

                int[] ids = line.AI_ID;
                foreach (var id in ids)
                {
                    if (dropBox.ContainsKey(id))
                    {
                        continue;
                    }
                    var AI = FindFromTheDataBase(id);
                    dropBox[id] = AI;
                }
            }
        }

        private AIDataBase FindFromTheDataBase(int num)
        {
            int min = 0;
            int max = allAIData.aiLists.Length - 1;

            while (min <= max)
            {
                int middle = (int)Math.Floor((double)(min + max) / 2);

                if (allAIData.aiLists[middle].id > num)
                {
                    max = middle - 1;
                }
                else if (allAIData.aiLists[middle].id < num)
                {
                    min = middle + 1;
                }
                else if (allAIData.aiLists[middle].id == num)
                {
                    return allAIData.aiLists[middle];
                }
            }
            return allAIData.aiLists[num];
        }

        public AIDataBase GetTheDataBase(int id)
        {
            return dropBox[id];
        }
        public RowGridSystem[] GetTheRowsGirds()
        {
            return rows;
        }

        public void UnitGenerated()
        {
            generatedQty++;
        }
    }
}
