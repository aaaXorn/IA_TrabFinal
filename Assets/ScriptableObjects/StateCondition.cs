using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "_Condition", menuName = "Scriptable Object/State Machine/Condition")]
public abstract class StateCondition : ScriptableObject
{
    //condition to change states
    public abstract bool Condition(StateMachine sm);
}
