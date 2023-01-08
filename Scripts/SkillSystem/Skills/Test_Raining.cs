using UnityEngine;
using System.Collections;
using SlimeProject_GridSystem;
using SlimeProject_UnitGeneratorSystem;
using SlimeProject_CombatElement;

namespace Slimeproject_SkillSystem
{
    public class Test_Raining : Skill_GlobalTypeBase
    {
        [SerializeField] GameObject waterPrefab;
        [SerializeField] int defaultRadius;

        private RowGridSystem[] allRows;
        private float _rainningTimes;
        private ElementManager _elementManager;
        private ParticleSystem _rainingVfx;

        // To avoid conflict set up at Start
        private void Start()
        {
            _elementManager = ElementManager.Instance;
            allRows = FindObjectOfType<WaveManager>().GetTheRowsGirds();
            _rainingVfx = GetComponentInChildren<ParticleSystem>();
            SetUpPosition();
        }

        private void SetUpPosition()
        {
            var cameraPos = Camera.main.transform.position;
            var posDelta = Camera.main.orthographicSize;
            _rainingVfx.transform.position = new Vector3(cameraPos.x, cameraPos.y + posDelta, 0);
        }

        public override void CastByEach()
        {
            _rainningTimes = data.parameter1;
            _rainingVfx.Play();
            float rainingduration = _rainingVfx.main.duration;
            float dropBreak = (rainingduration + 1) / _rainningTimes;
            StartCoroutine(Raining(dropBreak));
        }

        private IEnumerator Raining(float breakTime)
        {
            int countTime = 0;
            while (countTime < _rainningTimes)
            {
                countTime++;
                int index = GetTargetType();
                RowGridSystem targetRow = GetTaretRow(index);
                Transform targetGrid = GetTargetGrid(targetRow);
                Vector3 randomPos = GetRandomPos(targetGrid);
                GameObject waterPool = Instantiate(waterPrefab, GetRandomPos(targetGrid), Quaternion.identity);
                waterPool.transform.SetParent(_elementManager.transform);
                yield return new WaitForSeconds(breakTime);
            }
        }

        private int GetTargetType()
        {
            return Random.Range(0, allRows.Length);
        }

        private RowGridSystem GetTaretRow(int type)
        {
            return allRows[type];
        }
        private Transform GetTargetGrid(RowGridSystem row)
        {
            int index = Random.Range(0, row.grids.Count);
            return row.grids[index].GetComponent<Transform>();
        }

        private Vector3 GetRandomPos(Transform target)
        {
            int randomX = Random.Range(-defaultRadius, defaultRadius);
            int randomY = Random.Range(-defaultRadius, defaultRadius);

            Vector3 targetDrop = new Vector3(
                target.position.x + randomX,
                target.position.y + randomY,
                target.position.z);

            return targetDrop;
        }
    }
}