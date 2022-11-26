using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bool1False", menuName = "Scriptable Object/State Machine/Action/Start/Bool 1 False")]
public class Bool1False : StateAction
{
    public override void Action(StateMachine sm)
    {
        sm.bool1 = false;
        sm.GetNav().StopAgent();
    }
}
