using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Transition", menuName = "Scriptable Object/State Machine")]
public class StateTransition : ScriptableObject
{
    [Tooltip("Condition to change states.")]
    [SerializeField] StateCondition _condition;
    [Tooltip("Action made during the transition.")]
    [SerializeField] StateAction _action;
    [Tooltip("Next state after the transition.")]
    [SerializeField] State _targetState;

    //what triggers the condition
    public bool ConditionTrigger(StateMachine sm)
    {
        return _condition.Condition(sm);
    }

    //returns the next state
    public State GetTargetState()
    {
        return _targetState;
    }

    //gets the mid-transition action
    public StateAction GetAction()
    {
        return _action;
    }
}
