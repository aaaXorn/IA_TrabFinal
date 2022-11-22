using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : StateMachine
{
    Rigidbody _rigid;

    protected override void OnAwake()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    public Rigidbody GetRigid()
    {
        return _rigid;
    }
}
