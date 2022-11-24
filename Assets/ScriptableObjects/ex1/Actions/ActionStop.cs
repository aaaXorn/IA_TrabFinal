using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stop", menuName = "Scriptable Object/State Machine/Action/Stop")]
public class ActionStop : StateAction
{
    public override void Action(StateMachine sm)
    {
        sm.GetNav().StopAgent();
    }
}

