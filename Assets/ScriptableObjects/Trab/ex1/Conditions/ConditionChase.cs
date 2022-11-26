using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChaseCon", menuName = "Scriptable Object/State Machine/Condition/Chase")]
public class ConditionChase : StateCondition
{
    [Tooltip("LayerMask containing the player layer.")]
    [SerializeField] LayerMask _playerLM = (1 << 3);//(1 << 3) returns the third layer
    [Tooltip("Player Detection distance.")]
    [SerializeField] float _aggroDist = 10f;

    public override bool Condition(StateMachine sm)
    {
        //objects in range (only detects layers in the layermask)
        Collider[] hit = Physics.OverlapSphere(sm.transform.position, _aggroDist, _playerLM);
        
        //if there's an object in range
        if(hit.Length > 0)
        {
            //initializes variables
            Vector3 origin = sm.transform.position;
            Vector3 dir;

            RaycastHit ray_hit;
            Transform target = null;

            float target_dist = _aggroDist + 1f;
            float hit_dist = 0;

            //for each collider located
            foreach(Collider col in hit)
            {
                //raycast direction
                dir = (col.transform.position - origin).normalized;

                //line of sight
                if(Physics.Raycast(origin, dir, out ray_hit, _aggroDist))
                {
                    if(ray_hit.transform.CompareTag("Player"))
                    {
                        //distance
                        hit_dist = (ray_hit.transform.position - origin).magnitude;
                        //sets the target as the closest object with line of sight
                        if(hit_dist < target_dist)
                        {
                            target = ray_hit.transform;
                            target_dist = hit_dist;
                        }
                    }
                }
            }

            if(target != null)
            {
                //changes the navigation follow target
                sm.GetNav().ChangeTarget(target);
                return true;
            }
        }

        return false;
    }
}
