using System;
using Lean.Pool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace InternalAssets.Scripts.People
{
    public class PeoplesManagement : MonoBehaviour
    {
        [SerializeField] private LeanGameObjectPool poolPeoples;
        [Range(0f, 10f)]
        [SerializeField] private float maxRandomRange = 3f;
        
        private float _waitTime;
        private float _leftTime;

        private void Start()
        {
            _leftTime = GetRandomTime();
        }

        private void Update()
        {
            _leftTime -= Time.deltaTime;

            if (_leftTime < 0)
            {
                _leftTime = GetRandomTime();
                var people = poolPeoples.Spawn(poolPeoples.transform);
                people.transform.position = poolPeoples.transform.position;
                people.GetComponent<PeopleControl>().PoolPeoples = poolPeoples;
            }
        }

        private float GetRandomTime()
        {
            return Random.Range(1f, maxRandomRange);
        }
    }
}