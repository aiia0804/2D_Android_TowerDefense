using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeProject_BattleTimer
{
    public class TimerTestPurpose : MonoBehaviour
    {
        private Battle_Timer timer;
        private void Awake()
        {
            timer = FindObjectOfType<Battle_Timer>();
            //timer.AdjustToDefaultTime(5f);
        }
        void Start()
        {


        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                timer.AdjustToCurrtimeTime(2f);
            }
        }
    }
}