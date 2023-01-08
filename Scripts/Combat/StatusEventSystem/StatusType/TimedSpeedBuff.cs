using UnityEngine;

namespace SlimeProject_StatusEventSystem
{
    public class TimedSpeedBuff : TimedBuff
    {
        //private readonly WaypointsTraveler _wayPointTraveler;

        public TimedSpeedBuff(ScriptableBuff buff, GameObject obj) : base(buff, obj)
        {
            //Getting MovementComponent, replace with your own implementation
            //_wayPointTraveler = obj.GetComponent<WaypointsTraveler>();
        }

        protected override void ApplyEffect(float parameter)
        {
            //Add speed increase to MovementComponent
            ScriptableSpeedBuff speedBuff = (ScriptableSpeedBuff)Buff;
            //_wayPointTraveler.MoveSpeed += speedBuff.SpeedIncrease;
        }

        public override void End()
        {
            //Revert speed increase
            ScriptableSpeedBuff speedBuff = (ScriptableSpeedBuff)Buff;
            //_wayPointTraveler.MoveSpeed -= speedBuff.SpeedIncrease * EffectStacks;
            EffectStacks = 0;
        }
    }
}