using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StartPatrol", menuName = "Scriptable Object/State Machine/Action/Start/Patrol")]
public class ActionStartPatrol : StateAction
{
    public override void Action(StateMachine sm)
    {
        sm.GetNav().SetClosestWaypoint();
    }
}