using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : StateMachine
{
    Rigidbody _rigid;

    float _h_input;
    float _v_input;
    bool _pew_input;

    protected override void OnAwake()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    protected override void OnUpdate()
    {
        _h_input = Input.GetAxis("Horizontal");
        _v_input = Input.GetAxis("Vertical");
        _pew_input = Input.GetButtonDown("Fire1");
    }

    public Rigidbody GetRigid()
    {
        return _rigid;
    }
}
