using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recover", menuName = "Scriptable Object/State Machine/Action/Recover Energy")]
public class RecoverEnergy : StateAction
{
    [SerializeField] float _energyPerSec = 15f;

    public override void Action(StateMachine sm)
    {
        sm.float1 += _energyPerSec * Time.deltaTime;
    }
}