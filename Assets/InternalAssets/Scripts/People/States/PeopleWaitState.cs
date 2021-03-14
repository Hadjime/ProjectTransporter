using UnityEngine;

namespace InternalAssets.Scripts.People.States
{
    public class PeopleWaitState : IPeopleState
    {
        private PeopleControl _peopleControl;
        private float _timer;
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
            //уменьшение прогресбара доделать
            
            if (_leftTime < 0)
                SetStateMoveOut();
            
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