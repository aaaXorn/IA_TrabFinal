using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Action", menuName = "Scriptable Object/State Machine/Action")]
public abstract class StateAction : ScriptableObject
{
    //action done during the state
    public abstract void Action(StateMachine sm);
}
