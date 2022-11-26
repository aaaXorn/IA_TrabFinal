using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AddForce", menuName = "Scriptable Object/State Machine/Player/Action/Movement Add Force")]
public class PlayerMoveForce : PlayerAction
{
    [Tooltip("Move speed.")]
    [SerializeField] float _spd = 5;
    [Tooltip("Move force.")]
    [SerializeField] float _force = 5;
    [Tooltip("Move ForceMode.")]
    [SerializeField] ForceMode _fMode = ForceMode.Force;

    public override void Action(PlayerControl pc)
    {
        AddForce(pc.GetRigid(), pc.GetHInput(), pc.GetVInput());
    }

    void AddForce(Rigidbody rigid, float h_input, float v_input)
    {
        Vector3 vel = new Vector3(h_input, 0, v_input) * _spd;
        if(vel == Vector3.zero) return;

        vel += vel.normalized * 0.2f * rigid.drag;

        float force = Mathf.Clamp(_force, -rigid.mass / Time.fixedDeltaTime, rigid.mass / Time.fixedDeltaTime);

        if(rigid.velocity.magnitude == 0) rigid.AddForce(vel * force, _fMode);
        else
        {
            var velProjectedToTarget = (vel.normalized * Vector3.Dot(vel, rigid.velocity) / vel.magnitude);
            rigid.AddForce((vel - velProjectedToTarget) * force, _fMode);
        }
    }
}
