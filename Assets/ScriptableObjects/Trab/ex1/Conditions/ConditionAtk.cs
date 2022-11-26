using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AtkCon", menuName = "Scriptable Object/State Machine/Condition/Attack")]
public class ConditionAtk : StateCondition
{
    [Tooltip("Min distance from the target before starting the attack.")]
    [SerializeField] float _atkDist;

    public override bool Condition(StateMachine sm)
    {
        if(sm.GetNav().GetDistFromTarget() <= _atkDist)
        {
            return true;
        }

        return false;
    }
}
