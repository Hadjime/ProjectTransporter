using System;
using DG.Tweening;
using UnityEngine;

namespace InternalAssets.Scripts.People.States
{
    public class PeopleMoveInState: IPeopleState
    {
        private PeopleControl _peopleControl;

        public PeopleMoveInState(PeopleControl peopleControl)
        {
            _peopleControl = peopleControl;
        }

        public void Enter()
        {
            var point = _peopleControl.GetRandomTargetPoint();
            var duration = _peopleControl.Duration;
            _peopleControl.transform.DOMove(point, duration, false).OnComplete(SetStateWait);
        }

        public void Update()
        {

        }

        public void Exit()
        {
            
        }

        private void SetStateWait()
        {
            var state = _peopleControl.GetState<PeopleWaitState>();
            _peopleControl.PeopleFSM.ChangeState(state);
        }
    }
}