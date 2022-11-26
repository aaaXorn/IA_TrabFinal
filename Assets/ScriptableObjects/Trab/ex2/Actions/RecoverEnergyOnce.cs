using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecoverOnce", menuName = "Scriptable Object/State Machine/Action/Recover Energy Once")]
public class RecoverEnergyOnce : StateAction
{
    [SerializeField] float _energy = 45f;

    public override void Action(StateMachine sm)
    {
        sm.float1 = _energy;
    }
}