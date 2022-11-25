using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EndAtk", menuName = "Scriptable Object/State Machine/Action/Start/End Attack")]
public class ActionEndAtk : StateAction
{
    public override void Action(StateMachine sm)
    {
        sm.SetAtkIndicator(false);
    }
}
