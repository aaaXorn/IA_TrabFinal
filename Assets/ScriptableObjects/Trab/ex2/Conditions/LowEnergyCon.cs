using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LowEnCon", menuName = "Scriptable Object/State Machine/Condition/Low Energy")]
public class LowEnergyCon : StateCondition
{
    [SerializeField] float _targetEnergy = 15f;

    public override bool Condition(StateMachine sm)
    {
        return sm.float1 <= _targetEnergy;
    }
}
