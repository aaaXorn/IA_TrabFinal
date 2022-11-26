using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Navigation))]
public class StateMachine : MonoBehaviour
{
    Navigation _nav;

    [Tooltip("Initial state.")]
    [SerializeField] State _initState;
    //current state
    State _currState;

    [SerializeField] GameObject _atkIndicator;

    [Tooltip("Generic float variable, used in actions/conditions.")]
    public float float1, float2;
    [Tooltip("Generic bool variable, used in actions/conditions.")]
    public bool bool1;

    void Awake()
    {
        _nav = GetComponent<Navigation>();
    }

    void Start()
    {
        //sets the current state as the initial state
        _currState = _initState;

        SetAtkIndicator(false);
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

    public Navigation GetNav()
    {
        return _nav;
    }

    public void SetAtkIndicator(bool enabled)
    {
        _atkIndicator.SetActive(enabled);
    }
    public Vector3 GetAtkIndicatorPos()
    {
        return _atkIndicator.transform.position;
    }
}
