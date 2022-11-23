using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Movement", menuName = "Scriptable Object/State Machine/Player/Action")]
public class PlayerMovement : PlayerAction
{
    public override void Action(PlayerControl pc)
    {
        Rigidbody rigid = pc.GetRigid();
    }

    void MovementAddForce()
    {
        
    }
}
