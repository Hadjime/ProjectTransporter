using System;
using UnityEngine;

namespace InternalAssets.Scripts.UI
{
    [ExecuteAlways]
    public class LookAtCamera : MonoBehaviour
    {
        private Camera _camera;

        void Start()
        {
            _camera = GetComponent<Canvas>().worldCamera;
            transform.LookAt(transform.position + _camera.transform.forward);
        }
    }
}
