using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StopAtkCon", menuName = "Scriptable Object/State Machine/Condition/Stop Attack")]
public class ConditionStopAtk : StateCondition
{
    [Tooltip("Time until end of attack.")]
    [SerializeField] float _atkTimer;

    public override bool Condition(StateMachine sm)
    {
        if(sm.float1 >= _atkTimer)
        {
            sm.float1 = 0;
            return true;
        }

        return false;
    }
}
