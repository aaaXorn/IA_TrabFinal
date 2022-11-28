using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    [CreateAssetMenu(fileName = "DoEvent", menuName = "Scriptable Object/Test/Actions/Do Event")]
    public class ActionDoEvent : Action
    {
        [SerializeField] string _eventID = "Test";
        //action done during the state
        public override void DoAction(StateMachine sm)
        {
            sm.Event(_eventID);
        }
    }
}