using System;
using DG.Tweening;

namespace InternalAssets.Scripts.People.States
{
    public class PeopleMoveOutState : IPeopleState
    {
        private PeopleControl _peopleControl;

        public PeopleMoveOutState(PeopleControl peopleControl)
        {
            _peopleControl = peopleControl;
        }
        
        public void Enter()
        {
            var homePoint = _peopleControl.HomePoint;
            var duration = _peopleControl.Duration;
            _peopleControl.transform.DOMove(homePoint, duration, false);
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
            
        }
        
    }
}