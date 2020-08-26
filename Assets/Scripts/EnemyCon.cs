using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCon : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField]
    private GameObject target;

    void OnEnable()
    {
        target = GameObject.FindGameObjectWithTag("Target"); //Change this out for multiple Targets
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.transform.position);
    }

    //Returns distance left to target
    public float ReturnDistanceRemaing()
    {
        float DistanceRemaining = LengthOfPathToTarget(agent.path.corners);
        return DistanceRemaining;
    }

    //Finds distance left to target
    public float LengthOfPathToTarget(Vector3[] points)
    {
        if (points.Length < 2) return 0;
        float distance = 0;
        for (int i = 0; i < points.Length - 1; i++)
            distance += Vector3.Distance(points[i], points[i + 1]);
        return distance;
    }
}
