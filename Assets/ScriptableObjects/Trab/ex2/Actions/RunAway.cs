using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Run Away", menuName = "Scriptable Object/State Machine/Action/Run Away")]
public class RunAway : StateAction
{
    [SerializeField] float _targetDist = 5f;

    public override void Action(StateMachine sm)
    {
        Vector3 dir = (sm.transform.position - sm.GetNav().GetTarget().position);
        sm.GetNav().GoToDestination(dir);
    }
}
