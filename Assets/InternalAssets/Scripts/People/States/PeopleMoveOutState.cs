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
            _peopleControl.MoveOut();
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}