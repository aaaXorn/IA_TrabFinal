using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    [CreateAssetMenu(fileName = "LMB", menuName = "Scriptable Object/Test/Conditions/Left Mouse Button")]
    public class ConditionDoEvent : Condition
    {
        public override bool IsCondition(StateMachine sm)
        {
            return Input.GetMouseButtonDown(0);
        }
    }
}