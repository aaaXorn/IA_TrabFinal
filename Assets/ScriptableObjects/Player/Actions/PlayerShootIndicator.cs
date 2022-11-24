using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootIndicator", menuName = "Scriptable Object/State Machine/Player/Action/Shoot Indicator")]
public class PlayerShootIndicator : PlayerAction
{
    [Tooltip("If the indicator should be enabled or disabled.")]
    [SerializeField] bool _enable;

    public override void Action(PlayerControl pc)
    {
        pc.SetAtkIndicator(_enable);
    }
}
