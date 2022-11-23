using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerVel", menuName = "Scriptable Object/State Machine/Player/Action/Movement Velocity")]
public class PlayerVelocity : PlayerAction
{
    [Tooltip("Move speed.")]
    [SerializeField] float _spd = 5;

    public override void Action(PlayerControl pc)
    {
        Velocity(pc.GetRigid(), pc.GetHInput(), pc.GetVInput());
    }

    void Velocity(Rigidbody rigid, float h_input, float v_input)
    {
        Vector3 dir = new Vector3(h_input, 0, v_input);
        rigid.velocity = dir * _spd;
    }
}
