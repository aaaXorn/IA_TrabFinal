using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequiresComponent(typeof(NavMeshAgent))]
public class Navigation : MonoBehaviour
{
    [Tooltip("AI follow target.")]
    [SerializeField] Transform _target;
    [Tooltip("Patrol waypoints.")]
    [SerializeField] Transform[] _waypoints;
    int _currWaypoint = 0;
    NavMeshAgent _navAgent;

    void Awake()
    {
        _navAgent = GetComponent<NavMeshAgent>();
    }

    //patrols through an array of waypoints
    public void PatrolNextWaypoint()
    {
        _navAgent.destination = _waypoints[_currWaypoint].position;
        _currWaypoint++;
        if(_currWaypoint >= _waypoints.Length) _currWaypoint = 0;
    }

    //moves to a defined target (such as the player)
    public void GoToTarget()
    {
        agent.destination = target.position;
    }

    //stops the agent
    public void StopAgent()
    {
        agent.isStopped = true;
        agent.ResetPath();
    }

    //checks if the agent reached its destination
    public bool IsAtDestination()
    {
        if(!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance &&
            (!agent.hasPath || agent.velocity.sqrMagnitude == 0f))
        {
            return true;
        }

        return false;
    }

    //changes the target (not patrol target)
    public void ChangeTarget(Transform target)
    {
        _target = target;
    }

    //gets the target
    public Transform GetTarget()
    {
        return _target;
    }
}
