using System;
using System.Collections.Generic;
using DG.Tweening;
using InternalAssets.Scripts.People.States;
using UnityEngine;
using Random = UnityEngine.Random;

namespace InternalAssets.Scripts.People
{
    public class PeopleControl : MonoBehaviour
    {
        [SerializeField] private Vector3 targetPoint;
        [SerializeField] private float duration;

        private PeopleStateMachine _peopleFSM;
        private Dictionary<Type, IPeopleBehavior> _behaviorsMap;
        private IPeopleBehavior _currentBehavior;

        void Start()
        {
            InitBehaviors();
            SetBehaviorMovIn();
            _peopleFSM.Initialize(_behaviorsMap[typeof(PeopleMoveInState)]);
        }

        // Update is called once per frame
        void Update()
        {
            if (_currentBehavior != null)
            {
                _currentBehavior.Update();
            }
            _peopleFSM.CurrentBehavior.Update();
        }

        public Vector3 GetRandomTargetPoint()
        {
            return new Vector3(Random.Range(-1.5f, 2f), targetPoint.y, targetPoint.z);
        }
        
        public void Move(Vector3 point)
        {
            transform.DOMove(point, duration, false);
        }

        private void InitBehaviors()
        {
            _behaviorsMap = new Dictionary<Type, IPeopleBehavior>();

            _behaviorsMap[typeof(PeopleMoveInState)] = new PeopleMoveInState(this);
        }

        private void SetBehaviors(IPeopleBehavior newBehaviors)
        {
            if (_currentBehavior != null)
                _currentBehavior.Exit();

            _currentBehavior = newBehaviors;
            _currentBehavior.Enter();
        }

        private void SetBehaviorByDefault()
        {
            var behaviorByDefault = GetBehavior<PeopleMoveInState>();
            SetBehaviors(behaviorByDefault);
        }        
        
        private IPeopleBehavior GetBehavior<T>() where T : IPeopleBehavior
        {
            var type = typeof(T);
            return _behaviorsMap[type];
        }
        
        private void SetBehaviorMovIn()
        {
            var behaviorByDefault = GetBehavior<PeopleMoveInState>();
            SetBehaviors(behaviorByDefault);
        }   
    }
}
