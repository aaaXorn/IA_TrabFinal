using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "State", menuName = "Scriptable Object/State Machine/State")]
public class State : ScriptableObject
{
    [Tooltip("Action when entering this state.")]
    [SerializeField] StateAction _entryAction;
    [Tooltip("Actions made during the state.")]
    [SerializeField] StateAction[] _stateActions;
    [Tooltip("Action when exiting this state.")]
    [SerializeField] StateAction _exitAction;
    [Tooltip("This state's possible transitions.")]
    [SerializeField] StateTransition[] _transitions;

    //gets the actions made during this state
    public StateAction[] GetActions()
    {
        return _stateActions;
    }

    //gets the action made when first entering this state
    public StateAction GetEntryAction()
    {
        return _entryAction;
    }

    //gets the action made when switching from this state to another
    public StateAction GetExitAction()
    {
        return _exitAction;
    }

    //gets this state's possible transitions
    public StateTransition[] GetTransitions()
    {
        return _transitions;
    }
}
