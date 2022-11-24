using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AtkStart", menuName = "Scriptable Object/State Machine/Player/Condition/Attack Start")]
public class PlayerAtkStart : PlayerCondition
{
    public override bool Condition(PlayerControl pc)
    {
        return pc.GetPewInput();
    }
}
