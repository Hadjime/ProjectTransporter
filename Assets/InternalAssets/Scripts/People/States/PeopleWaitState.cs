using System;
using InternalAssets.Scripts.UI.Bar;
using UnityEngine;

namespace InternalAssets.Scripts.People.States
{
    public class PeopleWaitState : IPeopleState
    {
        private PeopleControl _peopleControl;
        private float _leftTime;

        private bool m_HitDetect;
        private int m_MaxDistance = 1;
        private RaycastHit m_Hit;

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

            
            Collider m_Collider = new Collider();
            m_HitDetect = Physics.BoxCast(Vector3.forward, _peopleControl.transform.localScale, _peopleControl.transform.forward, out m_Hit, _peopleControl.transform.rotation, m_MaxDistance);
            if (m_HitDetect)
            {
                //Output the name of the Collider your Box hit
                Debug.Log("Hit : " + m_Hit.collider.name);
            }
            
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
        
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            //Check if there has been a hit yet
            if (m_HitDetect)
            {
                //Draw a Ray forward from GameObject toward the hit
                Gizmos.DrawRay(_peopleControl.transform.position, _peopleControl.transform.forward * m_Hit.distance);
                //Draw a cube that extends to where the hit exists
                Gizmos.DrawWireCube(_peopleControl.transform.position + _peopleControl.transform.forward * m_Hit.distance, _peopleControl.transform.localScale);
            }
            //If there hasn't been a hit yet, draw the ray at the maximum distance
            else
            {
                //Draw a Ray forward from GameObject toward the maximum distance
                Gizmos.DrawRay(_peopleControl.transform.position, _peopleControl.transform.forward * m_MaxDistance);
                //Draw a cube at the maximum distance
                Gizmos.DrawWireCube(_peopleControl.transform.position + _peopleControl.transform.forward * m_MaxDistance, _peopleControl.transform.localScale);
            }
        }
    }
}