using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using InternalAssets.Scripts.Things;
using Lean.Pool;
using UnityEngine;
using UnityEngine.Events;

namespace InternalAssets.Scripts
{
    public class Tray : MonoBehaviour
    {
        public LeanGameObjectPool PoolTray { get; set; }

        [SerializeField] private List<GameObject> slots;
        [SerializeField] private List<GameObject> thingsPrefab;

        private Dictionary<ThingType, GameObject> _things;
        private int _counterSlot = 0;
        private List<GameObject> _createdObjects;
        private int CounterSlot
        {
            get => _counterSlot;
            set
            {
                if (value >= slots.Count)
                {
                    _counterSlot = slots.Count-1;
                }
                else _counterSlot = value;
            }
        }

        private Coroutine _corutine;

        private void Start()
        {
            _createdObjects = new List<GameObject>();
            _things = new Dictionary<ThingType, GameObject>();
            _things.Add(ThingType.Ball, thingsPrefab[0]);
            _things.Add(ThingType.Box, thingsPrefab[1]);
            _things.Add(ThingType.Parallelepiped, thingsPrefab[2]);
        }

        public void PutThing(string thingType)
        {
            var enumState = (ThingType)Enum.Parse(typeof(ThingType), thingType);
            var thing = _things[enumState];
            var parent = slots[CounterSlot].transform;
            var obj = Instantiate(thing, parent, false);
            _createdObjects.Add(obj);
            CounterSlot++;
        }

        public void StartMoveTray()
        {
            _corutine = StartCoroutine(MoveTray());
        }

        private void Update()
        {

        }

        public void Despawn()
        {
            PoolTray.Despawn(gameObject);
        }
        
        IEnumerator MoveTray()
        {
            Tween myTween = transform.DOMoveX(3.5f, 3);
            yield return myTween.WaitForRewind();
            Despawn();
            ClearSlots();
        }

        private void ClearSlots()
        {
            foreach (var obj in _createdObjects)
            {
                CounterSlot = 0;
                Destroy(obj);
            }
        }
    }
}
