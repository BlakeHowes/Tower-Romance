using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCon : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField]
    private GameObject target;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.transform.position);
    }

    public float ReturnDistanceRemaing()
    {
        float DistanceRemaining = LengthOfPathToTarget(agent.path.corners);
        return DistanceRemaining;
    }

    public float LengthOfPathToTarget(Vector3[] points)
    {
        if (points.Length < 2) return 0;
        float distance = 0;
        for (int i = 0; i < points.Length - 1; i++)
            distance += Vector3.Distance(points[i], points[i + 1]);
        return distance;
    }
}
