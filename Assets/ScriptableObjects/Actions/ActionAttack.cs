using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "Scriptable Object/State Machine/Action/Attack")]
public class ActionAttack : StateAction
{
    public override void Action(StateMachine sm)
    {
        if(sm.GetNav().IsAtDestination())
        {
            sm.GetNav().GoToNextWaypoint();
        }
    }
}
