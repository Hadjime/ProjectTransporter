using System;

namespace InternalAssets.Scripts.People.States
{
    public interface IPeopleState
    {
        void Enter();
        void Update();
        void Exit();
        
    }
}