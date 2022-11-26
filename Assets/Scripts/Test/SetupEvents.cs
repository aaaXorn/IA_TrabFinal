using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Test
{
    public class SetupEvents : MonoBehaviour
    {
        [Tooltip("Dictionary IDs.")]
        [SerializeField] string[] _ids;
        [Tooltip("Dictionary Unity Events. Must have the same length as the ID array.")]
        [SerializeField] UnityEvent[] _events;

        //State machine where the dictionary will be built.
        StateMachine _stateM;

        void Start()
        {
            foreach(string id in _ids)
            {
                
            }
        }
    }
}