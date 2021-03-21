using System;
using InternalAssets.Scripts.Things;
using Lean.Pool;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class TraysManagement : MonoBehaviour
    {
        public GameObject CurrentObject => _currentObject;
        
        [SerializeField] private LeanGameObjectPool poolTray;

        private GameObject _currentObject;


        private void Start()
        {
            SpawnTray();
        }

        private void OnTriggerExit(Collider other)
        {
            SpawnTray();
            
            Debug.Log("Tray liberated");
        }
        
        public void StartCurrentTray()
        {
            _currentObject.GetComponent<Tray>().StartMoveTray();
        }

        public void SpawnTray()
        {
            _currentObject = poolTray.Spawn(poolTray.transform, false);
            _currentObject.transform.position = poolTray.transform.position;
            _currentObject.GetComponent<Tray>().PoolTray = poolTray;
            Debug.Log("Transform parent = " + poolTray.transform);
        }

        public void PutThing(string nameThing)
        {
            CurrentObject.GetComponent<Tray>().PutThing(nameThing);
        }
        
    }
}