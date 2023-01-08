using System;
using UnityEngine;
namespace Slimeproject_SkillSystem
{
    public class SkillCharge_PartcileMove : MonoBehaviour
    {
        private bool _startToMove;
        private Vector3 _endPos;
        private Vector3 flyingDirection;
        [SerializeField] private float flyingSpeed;

        public void SetUp(Vector3 endPos)
        {
            _startToMove = true;
            _endPos = endPos;
            AdjustDirction(_endPos);
        }
        private void Update()
        {
            if (_startToMove)
            {
                HandleMove();
            }
        }

        private void HandleMove()
        {
            transform.position += flyingDirection * Time.deltaTime * flyingSpeed;
        }

        private void AdjustDirction(Vector3 target)
        {
            flyingDirection = (target - this.transform.position).normalized;
            Vector3 dir = target - this.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}