using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Test
{
    public class StateMachine : MonoBehaviour
    {
        [Tooltip("Initial state.")]
        [SerializeField] State _initState;
        //Current state of the state machine.
        State _currState;

        #region Unity Event Dictionary
        //Dictionary holding different functions.
        Dictionary<string, UnityEvent> Events = new Dictionary<string, UnityEvent>();

        public void AddEvent()//string id, UnityEvent event)
        {
            //Events.Add(id, event);
        }
        #endregion
    }
}