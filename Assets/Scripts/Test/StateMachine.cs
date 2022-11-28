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

        [Tooltip("Dictionary IDs.")]
        [SerializeField] string[] _ids;
        [Tooltip("Dictionary Unity Events. Must have the same length as the ID array.")]
        [SerializeField] UnityEvent[] _events;

        public void SetupEvents()
        {
            for(int i = 0; i < _ids.Length; i++)
            {
                Events.Add(_ids[i], _events[i]);
            }
            
            /*
            _ids = new string[0];
            _events = new UnityEvent[0];
            */
        }

        public void Event(string id)
        {
            UnityEvent uEvent = Events[id];
            uEvent?.Invoke();
        }
        #endregion

        void Start()
        {
            _currState = _initState;

            SetupEvents();
        }

        void Update()
        {
            Transition triggeredTransit = null;
            //checks the conditions for each transition
            foreach(Transition transit in _currState.GetTransitions())
            {
                if(transit.ConditionTrigger(this))
                {
                    //triggers the transitions
                    triggeredTransit = transit;
                    break;
                }
            }
            
            List<Action> actions = new List<Action>();

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
                foreach(Action act in _currState.GetActions())
                {
                    actions.Add(act);
                }
            }

            //commits the queued actions
            DoActions(actions);
        }

        //commits the specified actions
        void DoActions(List<Action> actions)
        {
            foreach(Action act in actions)
            {
                if(act != null) act.DoAction(this);
            }
        }

        public void Test()
        {
            Debug.Log("UnityEvent triggered.");
        }
    }
}