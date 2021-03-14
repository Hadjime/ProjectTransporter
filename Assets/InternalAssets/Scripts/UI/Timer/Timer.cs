using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InternalAssets.Scripts.UI.Timer
{
    public class Timer : MonoBehaviour
    {
        public static event Action OnTimeIsUp;
        public float Seconds => _seconds;
        public float Minutes => _minutes;
        
        [Range(0, 180)]
        [SerializeField] private int waitTime;

        [SerializeField] private Text textTimer;

        private float _leftTime;
        private float _elapsedTime;
        private float _seconds;
        private float _minutes;

        private void Start()
        {
            _elapsedTime = 0;
            _leftTime = waitTime;
        }

        private void Update()
        {
            _leftTime -= Time.deltaTime;
            _elapsedTime += Time.deltaTime;
            _seconds = Mathf.FloorToInt(_elapsedTime % 60);
            _minutes = Mathf.FloorToInt(_elapsedTime / 60);
            textTimer.text = string.Format("{0:00}:{1:00}", _minutes, _seconds);
            if (_leftTime < 0)
            {
                OnTimeIsUp?.Invoke();
                Debug.Log("Time Is Up. Game Over.");
            }
        }
    }
}