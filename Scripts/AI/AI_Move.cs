using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeProject_GridSystem;

namespace SlimeProject_AI
{

    public class AI_Move : MonoBehaviour
    {
        [SerializeField] private RowGridSystem currentRow;
        [SerializeField] private bool _reachTheEnd = false;
        [SerializeField] private bool _pausing = false;
        [SerializeField] int currentGrid;
        [SerializeField] private Vector3 targetPos;
        [SerializeField] float randomRange;

        private AI_Base _AI;
        private bool _readyToMove;
        private float _randomVetor;
        private Animator _animator;

        private void Awake()
        {
            _AI = GetComponent<AI_Base>();
            _randomVetor = Random.Range(-randomRange, randomRange);
            _animator = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            if (_AI.isParalizing || _reachTheEnd) { return; }
            if (_readyToMove)
            {
                Vector3 target = (targetPos - this.transform.position).normalized;
                this.transform.position += target * Time.deltaTime * _AI.dataBase.movingSpeed;
                if ((targetPos - this.transform.position).sqrMagnitude <= 0.1)
                {
                    _readyToMove = false;

                    if (_pausing)
                    {
                        _AI.ActionHandler(true, false);
                        _pausing = false;
                    }
                    if (currentGrid == 0)
                    {
                        _reachTheEnd = true;
                        _AI.isEnd = _reachTheEnd;
                    }
                }
                _animator.SetBool("Walk", _readyToMove);

            }
            //_animator.SetBool("Walk", _readyToMove);


        }
        public void SetUp(RowGridSystem row, int lastGrid)
        {
            currentRow = row;
            currentGrid = lastGrid;
        }

        public void Move(int movingSpeed)
        {
            int goalIndex = currentGrid - movingSpeed;
            int nextGoalIndex = currentGrid - 1;

            if (goalIndex < 0)
            {
                goalIndex = 0;
                _reachTheEnd = true;
                _AI.isEnd = _reachTheEnd;
                return;
            }
            else if (goalIndex > currentRow.grids.Count - 1)
            {
                goalIndex = currentRow.grids.Count - 1;
            }
            var toGoPos = new Vector3(currentRow.grids[goalIndex].transform.position.x + _randomVetor,
                                    currentRow.grids[goalIndex].transform.position.y + _randomVetor,
                                    currentRow.grids[goalIndex].transform.position.z);
            targetPos = toGoPos;
            _readyToMove = true;
            currentGrid = goalIndex;
        }

        public void Pausing()
        {
            _readyToMove = false;
            _pausing = true;
            _animator.SetBool("Walk", _readyToMove);
        }
        public void PasusingResume()
        {
            _readyToMove = true;
        }
        public void ProcessDeath()
        {
            _readyToMove = false;
        }

    }
}