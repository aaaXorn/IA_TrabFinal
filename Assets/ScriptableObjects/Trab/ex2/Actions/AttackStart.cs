using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AtkStart", menuName = "Scriptable Object/State Machine/Action/Start/Attack Start")]
public class AttackStart : StateAction
{
    public override void Action(StateMachine sm)
    {
        sm.float2 = 0;

        sm.GetNav().ChangeTarget(PlayerControl.singleton.transform);
    }
}