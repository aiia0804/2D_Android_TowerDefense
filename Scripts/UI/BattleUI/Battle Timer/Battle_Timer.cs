using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace SlimeProject_BattleTimer
{
    public class Battle_Timer : MonoBehaviour
    {
        /// <summary>
        /// 預計倒數時間。
        /// </summary>
        /// <returns></returns>
        [SerializeField] private float defaultTime;
        /// <summary>
        /// 每回合時間讀取. 
        /// </summary>
        /// <returns></returns>
        [SerializeField] private float defaultTimeBreak;
        /// <summary>
        /// ADV後開數倒數的時間
        /// </summary>
        /// <returns></returns>
        [SerializeField] float defaultTimeToCount;
        /// <summary>
        /// 是否可以COUNTDOWN
        /// </summary>
        /// <returns></returns>
        [SerializeField] bool readyToCount = false;
        [SerializeField] TextMeshProUGUI timerDisplay;
        [SerializeField] TextMeshProUGUI startCountDownDisplay;

        [SerializeField] private float currentTime;
        [SerializeField] private float CDTime;
        private float timeToCount;
        bool startFinsihed = false;

        public static event Action timeUp;

        private void Start()
        {
            currentTime = defaultTime;
            CDTime = defaultTimeBreak;
            timeToCount = defaultTimeToCount;

            ///測試用放在這, 之後改成一個method (開場結束後conunt to count)
            InvokeRepeating(nameof(CountToCount), 0f, 1f);
        }
        void Update()
        {
            if (readyToCount)
            {
                timerDisplay.gameObject.SetActive(true);
                CountDown();
            }
            else if (!readyToCount && startFinsihed)
            {
                timerDisplay.gameObject.SetActive(false);
                BreakCountDown();
            }
        }
        private void CountToCount()
        {
            startCountDownDisplay.gameObject.SetActive(true);
            startCountDownDisplay.text = timeToCount.ToString();
            timeToCount -= 1f;

            if (timeToCount < 0f)
            {
                CancelInvoke(nameof(CountToCount));
                startCountDownDisplay.text = "Start!!";
                Invoke(nameof(ReadyToCountDown), 1.5f);
            }
        }
        private void ReadyToCountDown()
        {
            readyToCount = true;
            startFinsihed = true;
            startCountDownDisplay.gameObject.SetActive(false);
        }

        private void CountDown()
        {
            currentTime -= Time.deltaTime;
            timerDisplay.text = Math.Round(currentTime, 1).ToString();

            if (currentTime <= 0)
            {
                timeUp?.Invoke();
                Debug.Log("TimeUP!!");
                readyToCount = false;
                currentTime = defaultTime;
            }
        }
        private void BreakCountDown()
        {
            CDTime -= Time.deltaTime;
            if (CDTime <= 0)
            {
                readyToCount = true;
                CDTime = defaultTimeBreak;
            }
        }

        public void AdjustToDefaultTime(float time)
        {
            defaultTime += time;
            currentTime += time;
        }

        public void AdjustToCurrtimeTime(float time)
        {
            currentTime += time;
        }
    }
}