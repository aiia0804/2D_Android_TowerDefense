using UnityEngine;
using System;

namespace SlimeProject_Combat
{
    public class BuffGiver : CarrierBase
    {
        public event Action animationFinished;

        public override void Attack()
        {
            animationFinished?.Invoke();
        }
    }
}