using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RunAwayCon", menuName = "Scriptable Object/State Machine/Condition/Run Away")]
public class RunAwayCon : StateCondition
{
    [SerializeField] float _targetDist = 10f;
    [SerializeField] float _targetEnergy = 44f;

    public override bool Condition(StateMachine sm)
    {
        return (sm.GetNav().GetDistFromTarget() >= _targetDist && sm.float1 <= _targetEnergy);
    }
}