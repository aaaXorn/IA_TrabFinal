using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BackToSearchCon", menuName = "Scriptable Object/State Machine/Condition/Return to Search")]
public class BackToSearchCon : StateCondition
{
    [SerializeField] float _targetDist = 10f;

    public override bool Condition(StateMachine sm)
    {
        return (sm.bool1 || sm.GetNav().GetDistFromTarget() >= _targetDist);
    }
}