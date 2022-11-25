using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IsntHurt", menuName = "Scriptable Object/State Machine/Player/Condition/Isn't Hurt")]
public class PlayerHurtStop : PlayerCondition
{
    public override bool Condition(PlayerControl pc)
    {
        return !pc.GetHP().IsHurt();
    }
}
