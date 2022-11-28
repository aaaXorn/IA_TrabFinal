using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    [CreateAssetMenu(fileName = "Transition", menuName = "Scriptable Object/Test/Transition")]
    public class Transition : ScriptableObject
    {
        [Tooltip("Condition to change states.")]
        [SerializeField] Condition _condition;
        [Tooltip("Action made during the transition.")]
        [SerializeField] Action _action;
        [Tooltip("Next state after the transition.")]
        [SerializeField] State _targetState;

        //what triggers the condition
        public bool ConditionTrigger(StateMachine sm)
        {
            return _condition.IsCondition(sm);
        }

        //returns the next state
        public State GetTargetState()
        {
            return _targetState;
        }

        //gets the mid-transition action
        public Action GetAction()
        {
            return _action;
        }
    }
}