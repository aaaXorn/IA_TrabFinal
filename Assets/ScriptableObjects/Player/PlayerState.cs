using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "State", menuName = "Scriptable Object/State Machine/Player/State")]
public class PlayerState : ScriptableObject
{
    [Tooltip("Action when entering this state.")]
    [SerializeField] PlayerAction _entryAction;
    [Tooltip("Actions made during the state.")]
    [SerializeField] PlayerAction[] _stateActions;
    [Tooltip("Actions made during the state in FixedUpdate().")]
    [SerializeField] PlayerAction[] _statePhysicsActions;
    [Tooltip("Action when exiting this state.")]
    [SerializeField] PlayerAction _exitAction;
    [Tooltip("This state's possible transitions.")]
    [SerializeField] PlayerTransition[] _transitions;

    public PlayerAction[] GetActions()
    {
        return _stateActions;
    }

    public PlayerAction[] GetPhysicsActions()
    {
        return _statePhysicsActions;
    }

    public PlayerAction GetEntryAction()
    {
        return _entryAction;
    }

    public PlayerAction GetExitAction()
    {
        return _exitAction;
    }

    public PlayerTransition[] GetTransitions()
    {
        return _transitions;
    }
}
