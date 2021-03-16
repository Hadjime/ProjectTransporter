using System;
using System.Collections.Generic;
using DG.Tweening;
using InternalAssets.Scripts.People.States;
using InternalAssets.Scripts.UI.Bar;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

namespace InternalAssets.Scripts.People
{
    public class PeopleControl : MonoBehaviour
    {
        public event Action<float> OnChangedWaitTimeEvent;
        public event Action OnResetWaitTimeEvent;
        public Vector3 HomePoint => homePoint;
        public float Duration => duration;
        public float WaitTime => waitTime;
        public PeopleStateMachine PeopleFSM;

        [SerializeField] private Vector3 homePoint;
        [SerializeField] private Vector3 targetPoint;
        [SerializeField] private float duration;
        [Range(0f, 10f)]
        [SerializeField] private float waitTime;

        private Dictionary<Type, IPeopleState> _statesMap;

        private void Awake()
        {
            PeopleFSM = new PeopleStateMachine();
        }

        void Start()
        {
            InitStates();
            PeopleFSM.Initialize(_statesMap[typeof(PeopleMoveInState)]);
        }

        void Update()
        {
            PeopleFSM.CurrentState.Update();
        }

        public Vector3 GetRandomTargetPoint()
        {
            return new Vector3(Random.Range(-1.5f, 2f), targetPoint.y, targetPoint.z);
        }

        private void InitStates()
        {
            _statesMap = new Dictionary<Type, IPeopleState>();
            _statesMap[typeof(PeopleMoveInState)] = new PeopleMoveInState(this);
            _statesMap[typeof(PeopleMoveOutState)] = new PeopleMoveOutState(this);
            _statesMap[typeof(PeopleWaitState)] = new PeopleWaitState(this);
        }
   
        
        public IPeopleState GetState<T>() where T : IPeopleState
        {
            var type = typeof(T);
            return _statesMap[type];
        }

        public void OnChangedWaitTime(float value)
        {
            OnChangedWaitTimeEvent?.Invoke(value);
        }

        public void OnResetWaitTime()
        {
            OnResetWaitTimeEvent?.Invoke();
        }
    }
}
