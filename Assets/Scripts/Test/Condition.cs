using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    //[CreateAssetMenu(fileName = "Condition", menuName = "Scriptable Object/Test/Conditions/")]
    public abstract class Condition : ScriptableObject
    {
        //condition to change states
        public abstract bool IsCondition(StateMachine sm);
    }
}