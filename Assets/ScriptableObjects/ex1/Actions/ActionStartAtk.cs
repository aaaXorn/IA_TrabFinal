using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StartAtk", menuName = "Scriptable Object/State Machine/Action/Start/Start Attack")]
public class ActionStartAtk : StateAction
{
    public override void Action(StateMachine sm)
    {
        sm.SetAtkIndicator(true);
        sm.float1 = 0;
    }
}
