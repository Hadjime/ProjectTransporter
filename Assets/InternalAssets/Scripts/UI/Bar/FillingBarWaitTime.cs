using System;
using InternalAssets.Scripts.People.States;
using UnityEngine;
using UnityEngine.UI;

namespace InternalAssets.Scripts.UI.Bar
{
    public class FillingBarWaitTime : MonoBehaviour
    {
        [SerializeField] private Image fillingImage;

        private void OnEnable()
        {
            PeopleWaitState.OnChangedWaitTimeEvent += SetTimeNormalized;
        }

        private void OnDisable()
        {
            PeopleWaitState.OnChangedWaitTimeEvent -= SetTimeNormalized;
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