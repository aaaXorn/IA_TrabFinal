using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IsHurt", menuName = "Scriptable Object/State Machine/Player/Condition/Is Hurt")]
public class PlayerIsHurt : PlayerCondition
{
    public override bool Condition(PlayerControl pc)
    {
        return pc.GetHP().IsHurt();
    }
}
