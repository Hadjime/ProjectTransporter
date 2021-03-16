using System;
using InternalAssets.Scripts.People;
using InternalAssets.Scripts.People.States;
using UnityEngine;
using UnityEngine.UI;

namespace InternalAssets.Scripts.UI.Bar
{
    public class FillingBarWaitTime : MonoBehaviour
    {
        [SerializeField] private Image fillingImage;

        private PeopleControl _peopleControl;
        
        private void Awake()
        {
            _peopleControl = GetComponentInParent<PeopleControl>();
        }
        
        private void OnEnable()
        {
            if (_peopleControl != null)
            {
                _peopleControl.OnChangedWaitTimeEvent += SetTimeNormalized;
                _peopleControl.OnResetWaitTimeEvent += ResetTime;
            }
        }

        private void OnDisable()
        {
            if (_peopleControl != null)
            {
                _peopleControl.OnChangedWaitTimeEvent += SetTimeNormalized;
                _peopleControl.OnResetWaitTimeEvent += ResetTime;
            }
        }

        

        public void SetTimeNormalized(float timeNorm)
        {
            fillingImage.fillAmount = timeNorm;
        }

        public void ResetTime()
        {
            fillingImage.fillAmount = 1;
        }
    }
}