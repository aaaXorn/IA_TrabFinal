using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
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
    public void GoToNextWaypoint()
    {
        _navAgent.destination = _waypoints[_currWaypoint].position;
        _currWaypoint++;
        if(_currWaypoint >= _waypoints.Length) _currWaypoint = 0;
    }

    //moves to a defined target (such as the player)
    public void GoToTarget()
    {
        _navAgent.destination = _target.position;
    }
    //moves to a defined point
    public void GoToDestination(Vector3 point)
    {
        _navAgent.destination = point;
    }

    //stops the agent
    public void StopAgent()
    {
        _navAgent.isStopped = true;
        _navAgent.ResetPath();
    }

    //checks if the agent reached its destination
    public bool IsAtDestination()
    {
        if(!_navAgent.pathPending && _navAgent.remainingDistance <= _navAgent.stoppingDistance &&
            (!_navAgent.hasPath || _navAgent.velocity.sqrMagnitude == 0f))
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

    public void SetClosestWaypoint()
    {
        float lowest_dist = Mathf.Infinity;
        float dist;
        int waypoint = 0;

        for(int i = 0; i < _waypoints.Length; i++)
        {
            dist = (_waypoints[i].position - transform.position).magnitude;

            if(dist < lowest_dist) waypoint = i;
        }
        
        _currWaypoint = waypoint;
    }

    public float GetRemainingDist()
    {
        return _navAgent.remainingDistance;
    }
    public float GetDistFromTarget()
    {
        return (_target.position - transform.position).magnitude;
    }
    public Vector3 GetDirToTarget()
    {
        return (_target.position - transform.position).normalized;
    }
}
