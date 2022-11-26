using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AtkEnd", menuName = "Scriptable Object/State Machine/Player/Condition/Attack End")]
public class PlayerAtkEnd : PlayerCondition
{
    public override bool Condition(PlayerControl pc)
    {
        return !pc.GetPewInput();
    }
}
