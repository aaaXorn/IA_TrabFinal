using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PatrolCon", menuName = "Scriptable Object/State Machine/Condition/Patrol")]
public class ConditionPatrol : StateCondition
{
    [Tooltip("Max distance from the target before giving up and returning to patrol.")]
    [SerializeField] float _disengageDist;

    public override bool Condition(StateMachine sm)
    {
        if(sm.GetNav().GetDistFromTarget() >= _disengageDist)
        {
            return true;
        }

        return false;
    }
}