using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chase", menuName = "Scriptable Object/State Machine/Action/Chase")]
public class ActionChase : StateAction
{
    public override void Action(StateMachine sm)
    {
        sm.GetNav().GoToTarget();
    }
}
