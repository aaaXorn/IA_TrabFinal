using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    //[CreateAssetMenu(fileName = "Action", menuName = "Scriptable Object/Test/Actions")]
    public abstract class Action : ScriptableObject
    {
        //action done during the state
        public abstract void DoAction(StateMachine sm);
    }
}