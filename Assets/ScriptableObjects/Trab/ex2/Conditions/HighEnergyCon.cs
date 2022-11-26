using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HighEnCon", menuName = "Scriptable Object/State Machine/Condition/High Energy")]
public class HighEnergyCon : StateCondition
{
    [SerializeField] float _targetEnergy = 45f;

    public override bool Condition(StateMachine sm)
    {
        return sm.float1 >= _targetEnergy;
    }
}
