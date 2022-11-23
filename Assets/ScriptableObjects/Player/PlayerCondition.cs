using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Condition", menuName = "Scriptable Object/State Machine/Player/Condition")]
public abstract class PlayerCondition : ScriptableObject
{
    public abstract bool Condition(PlayerControl pc);
}
