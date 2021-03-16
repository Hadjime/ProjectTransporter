using System;
using InternalAssets.Scripts.UI.Bar;
using UnityEngine;

namespace InternalAssets.Scripts.People.States
{
    public class PeopleWaitState : IPeopleState
    {
        private PeopleControl _peopleControl;
        private float _leftTime;

        public PeopleWaitState(PeopleControl peopleControl)
        {
            _peopleControl = peopleControl;
        }

        public void Enter()
        {
            _leftTime = _peopleControl.WaitTime;
        }

        public void Update()
        {
            _leftTime -= Time.deltaTime;
            
            var normalizedTime = _leftTime / _peopleControl.WaitTime;
            _peopleControl.OnChangedWaitTime(normalizedTime);
            
            if (_leftTime < 0)
            {
                SetStateMoveOut();
                _peopleControl.OnResetWaitTime();
            }
        }

        public void Exit()
        {
            
        }
        
        private void SetStateMoveOut()
        {
            var state = _peopleControl.GetState<PeopleMoveOutState>();
            _peopleControl.PeopleFSM.ChangeState(state);
        }
    }
}