using UnityEngine;
namespace SlimeProject_AIDataBase;
using SlimeProject_Combat;
using SlimeProject_BattleTimer;
using SlimeProject_GridSystem;
using SlimeProject_ClassificationSheet;

namespace SlimeProject_AI
{
    public class AI_Base : MonoBehaviour
    {
        public AIDataBase dataBase;
        private Health _health;
        private AI_Move _moveSystem;
        public bool isDeath = false;
        public bool isMoveAble = true;
        public bool isAttacking = false;
        public bool isParalizing = false;
        public bool isEnd = false;
        private Animator _myAnimator;
        public UnitType unitType;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _moveSystem = GetComponent<AI_Move>();
            _myAnimator = GetComponentInChildren<Animator>();
        }
        private void OnEnable()
        {
            _health.UnitOnDie += ProcessDeath;
            Battle_Timer.timeUp += HandleMove;
        }
        private void OnDisable()
        {
            _health.UnitOnDie -= ProcessDeath;
            Battle_Timer.timeUp -= HandleMove;
        }
        public void SetUpData(AIDataBase dataBase, RowGridSystem currentRow)
        {
            this.dataBase = dataBase;
            _health.SetUpData(dataBase.healthPoint, dataBase.elementType, dataBase.defense);
            _moveSystem.SetUp(currentRow, currentRow.grids.Count - 1);
            unitType = UnitType.AI;
            HandleMove();
        }
        private void ProcessDeath()
        {
            isDeath = true;
            isAttacking = false;
            isMoveAble = false;
            _moveSystem.ProcessDeath();
            Invoke(nameof(Death), 1.5f);
        }
        private void HandleMove()
        {
            if (!isDeath && isMoveAble && !isAttacking && !isParalizing)
            {
                _moveSystem.Move(dataBase.mvoingPoint);
            }
        }
        /// <summary>
        /// Adjust the move and attack status
        /// </summary>
        /// <param name="isMoveAble"></param>
        /// <param name="isAttacking"></param>
        public void ActionHandler(bool isMoveAble, bool isAttacking)
        {
            this.isMoveAble = isMoveAble;
            this.isAttacking = isAttacking;
            PausingSystem();
        }

        public void PausingSystem()
        {
            if (isAttacking)
            {
                _moveSystem.Pausing();
            }
            else
            {
                _moveSystem.PasusingResume();
            }
        }

        public void SetUpParalyzing(bool status)
        {
            isParalizing = status;
            if (isParalizing)
            {
                _myAnimator.enabled = false;
            }
            else
            {
                _myAnimator.enabled = true;
            }
        }

        private void Death()
        {
            Destroy(this.gameObject);
        }


    }
}