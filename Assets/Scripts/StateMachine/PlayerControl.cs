using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour
{
    [Tooltip("Initial state.")]
    [SerializeField] PlayerState _initState;
    PlayerState _currState;

    
    Rigidbody _rigid;

    float _h_input;
    float _v_input;
    bool _pew_input;

    void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    void Start()
    {
        _currState = _initState;
    }

    void Update()
    {
        _h_input = Input.GetAxis("Horizontal");
        _v_input = Input.GetAxis("Vertical");
        _pew_input = Input.GetButtonDown("Fire1");

        PlayerTransition triggeredTransit = null;
        foreach(PlayerTransition transit in _currState.GetTransitions())
        {
            if(transit.ConditionTrigger(this))
            {
                triggeredTransit = transit;
                break;
            }
        }
        
        List<PlayerAction> actions = new List<PlayerAction>();

        if(triggeredTransit != null)
        {
            PlayerState targetState = triggeredTransit.GetTargetState();

            actions.Add(_currState.GetExitAction());
            actions.Add(triggeredTransit.GetAction());
            actions.Add(targetState.GetEntryAction());

            _currState = targetState;
        }
        else
        {
            foreach(PlayerAction act in _currState.GetActions())
            {
                actions.Add(act);
            }
        }

        DoActions(actions);
    }

    void DoActions(List<PlayerAction> actions)
    {
        foreach(PlayerAction act in actions)
        {
            if(act != null) act.Action(this);
        }
    }

    void FixedUpdate()
    {
        //does all the 
        List<PlayerAction> actions = new List<PlayerAction>();

        foreach(PlayerAction act in _currState.GetPhysicsActions())
        {
            actions.Add(act);
        }

        DoActions(actions);
    }

    public Rigidbody GetRigid()
    {
        return _rigid;
    }
    public float GetHInput()
    {
        return _h_input;
    }
    public float GetVInput()
    {
        return _v_input;
    }
}
