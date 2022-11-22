using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateMachine : MonoBehaviour
{
    [Tooltip("Initial state.")]
    [SerializeField] State _initState;
    //current state
    State _currState;

    void Start()
    {
        //sets the current state as the initial state
        _currState = _initState;
    }

    void Update()
    {
        StateTransition triggeredTransit = null;
        //checks the conditions for each transition
        foreach(StateTransition transit in _currState.GetTransitions())
        {
            if(transit.ConditionTrigger(this))
            {
                //triggers the transitions
                triggeredTransit = transit;
                break;
            }
        }
        
        List<StateAction> actions = new List<StateAction>();

        //changes this state to the next
        if(triggeredTransit != null)
        {
            State targetState = triggeredTransit.GetTargetState();

            //transition actions
            actions.Add(_currState.GetExitAction());
            actions.Add(triggeredTransit.GetAction());
            actions.Add(targetState.GetEntryAction());

            _currState = targetState;
        }
        else
        {
            //does the mid-state actions
            foreach(StateAction act in _currState.GetActions())
            {
                actions.Add(act);
            }
        }

        //commits the queued actions
        DoActions(actions);
    }

    //commits the specified actions
    void DoActions(List<StateAction> actions)
    {
        foreach(StateAction act in actions)
        {
            if(act != null) act.Action(this);
        }
    }
}
