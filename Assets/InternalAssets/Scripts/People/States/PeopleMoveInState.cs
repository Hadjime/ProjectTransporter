namespace InternalAssets.Scripts.People.States
{
    public class PeopleMoveInState: IPeopleBehavior
    {
        private PeopleControl _peopleControl;
        
        public PeopleMoveInState(PeopleControl peopleControl)
        {
            _peopleControl = peopleControl;
        }

        public void Enter()
        {
            var targetPoint = _peopleControl.GetRandomTargetPoint();
            _peopleControl.Move(targetPoint);
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}