using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Transition", menuName = "Scriptable Object/State Machine/Player/Transition")]
public class PlayerTransition : ScriptableObject
{
    [Tooltip("Condition to change states.")]
    [SerializeField] PlayerCondition _condition;
    [Tooltip("Action made during the transition.")]
    [SerializeField] PlayerAction _action;
    [Tooltip("Next state after the transition.")]
    [SerializeField] PlayerState _targetState;

    public bool ConditionTrigger(PlayerControl pc)
    {
        return _condition.Condition(pc);
    }

    public PlayerState GetTargetState()
    {
        return _targetState;
    }

    public PlayerAction GetAction()
    {
        return _action;
    }
}
