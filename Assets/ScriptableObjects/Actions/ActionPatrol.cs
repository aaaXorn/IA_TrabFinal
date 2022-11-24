using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Patrol", menuName = "Scriptable Object/State Machine/Action/Patrol")]
public class ActionPatrol : StateAction
{
    public override void Action(StateMachine sm)
    {
        if(!sm.GetNav().IsAtDestination())
        {
            sm.GetNav().GoToNextWaypoint();
        }
    }
}
