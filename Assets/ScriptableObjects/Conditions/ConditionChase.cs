using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionChase : StateCondition
{
    [SerializeField] LayerMask _playerLM = (1 << 3);

    [SerializeField] float _aggroDist = 10f;

    [SerializeField] float _rcDist = 10f;

    public override bool Condition(StateMachine sm)
    {
        Collider[] hit = Physics.OverlapSphere(sm.transform.position, _aggroDist, _playerLM);
        
        if(hit.Length > 0)
        {
            Vector3 origin = sm.transform.position;
            Vector3 dir = Vector3.zero;

            foreach(Collider col in hit)
            {
                dir = (col.transform.position - origin).normalized;

                //if(Raycast(origin, dir, _rcDist, _playerLM))
            }
        }

        return false;
    }
}
