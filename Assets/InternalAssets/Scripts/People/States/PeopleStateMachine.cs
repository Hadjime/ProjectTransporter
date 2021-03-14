using UnityEngine.Rendering;

namespace InternalAssets.Scripts.People.States
{
    public class PeopleStateMachine
    {
        public IPeopleBehavior CurrentBehavior { get; private set; }

        public void Initialize(IPeopleBehavior startingBehavior)
        {
            CurrentBehavior = startingBehavior;
            CurrentBehavior.Enter();
        }

        public void ChangeBehavior(IPeopleBehavior newBehavior)
        {
            CurrentBehavior.Exit();
            CurrentBehavior = newBehavior;
            CurrentBehavior.Enter();
        }
    }
}