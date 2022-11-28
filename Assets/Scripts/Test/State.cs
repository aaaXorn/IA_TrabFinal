using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    [CreateAssetMenu(fileName = "State", menuName = "Scriptable Object/Test/State")]
    public class State : ScriptableObject
    {
        [Tooltip("Action when entering this state.")]
        [SerializeField] Action _entryAction;
        [Tooltip("Actions made during the state.")]
        [SerializeField] Action[] _stateActions;
        [Tooltip("Action when exiting this state.")]
        [SerializeField] Action _exitAction;
        [Tooltip("This state's possible transitions.")]
        [SerializeField] Transition[] _transitions;

        //gets the actions made during this state
        public Action[] GetActions()
        {
            return _stateActions;
        }

        //gets the action made when first entering this state
        public Action GetEntryAction()
        {
            return _entryAction;
        }

        //gets the action made when switching from this state to another
        public Action GetExitAction()
        {
            return _exitAction;
        }

        //gets this state's possible transitions
        public Transition[] GetTransitions()
        {
            return _transitions;
        }
    }
}