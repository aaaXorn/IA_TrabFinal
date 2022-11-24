using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StartChase", menuName = "Scriptable Object/State Machine/Action/Start/Chase")]
public class ActionStartChase : StateAction
{
    [Tooltip("Spotted VFX prefab.")]
    [SerializeField] GameObject _spottedVFX;
    [Tooltip("Offset between the VFX and the object.")]
    [SerializeField] Vector3 _spawnOffset;

    public override void Action(StateMachine sm)
    {
        Instantiate(_spottedVFX, sm.transform.position + _spawnOffset, Quaternion.identity);
    }
}