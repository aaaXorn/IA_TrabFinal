using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnergyShot", menuName = "Scriptable Object/State Machine/Action/Energy Shot")]
public class EnergyShot : StateAction
{
    [SerializeField] float _shootTime = 1f;
    [SerializeField] float _shootCost = 15f;

    [SerializeField] GameObject _shootPrefab;

    [SerializeField] Vector3 _offset = new Vector3(0, 0.5f, 0);

    public override void Action(StateMachine sm)
    {
        sm.float2 += Time.deltaTime;

        if(sm.float2 >= _shootTime)
        {
            GameObject obj = Instantiate(_shootPrefab, sm.transform.position + _offset, Quaternion.identity);
            Vector3 pos = PlayerControl.singleton.transform.position;
            pos = new Vector3(pos.x, obj.transform.position.y, pos.z);
            obj.transform.LookAt(pos);

            obj.GetComponent<EnergyPew>().SetOwner(sm);

            sm.float1 -= _shootCost;
            sm.float2 = 0;
        }
    }
}

