using UnityEngine.Rendering;

namespace InternalAssets.Scripts.People.States
{
    public class PeopleStateMachine
    {
        public IPeopleState CurrentState { get; private set; }

        public void Initialize(IPeopleState startingState)
        {
            CurrentState = startingState;
            CurrentState.Enter();
        }

        public void ChangeState(IPeopleState newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}