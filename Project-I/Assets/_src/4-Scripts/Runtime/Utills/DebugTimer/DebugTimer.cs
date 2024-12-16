using System;
using TMPro;
using UnityEngine;

namespace ProjectI.Utills.DebugTimer
{
    public class DebugTimer : MonoBehaviour
    {
        [SerializeField] private KeyCode startTimer = KeyCode.T;
        [SerializeField] private KeyCode stopTimer = KeyCode.T;
        [Space]
        [SerializeField] private TextMeshProUGUI time;

        private float timer;
        private bool isTimerRunning;

        private void Update()
        {
            if (Input.GetKeyDown(startTimer))
            {
                StartTimer();
            }
            else if (isTimerRunning && Input.GetKeyDown(stopTimer))
            {
                StopTimer();
            }

            if (isTimerRunning)
            {
                timer += Time.deltaTime;
                var timeSpan = TimeSpan.FromSeconds(timer);
                time.text = $"{timeSpan.Minutes} : {timeSpan.Seconds} : {timeSpan.Milliseconds}";
            }
        }

        private void StartTimer()
        {
            isTimerRunning = true;
            timer = 0;
        }

        private void StopTimer()
        {
            isTimerRunning = false;
        }
    }
}