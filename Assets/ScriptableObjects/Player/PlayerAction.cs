using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Action", menuName = "Scriptable Object/State Machine/Player/Action")]
public abstract class PlayerAction : ScriptableObject
{
    public abstract void Action(PlayerControl pc);
}
