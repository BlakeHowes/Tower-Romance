using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCon : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float Damage;
    [SerializeField]
    private bool parabolicArc;
    [SerializeField]
    private float arcDegrees;
    private Rigidbody rb;
    private GameObject Target;

    private float TotalDistance;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Shoot(GameObject target)
    {
        if(parabolicArc == false)
        {
            transform.LookAt(target.transform.position);
            rb.velocity = transform.forward * speed;
        }

        Target = target;

        var direction = Target.transform.position - transform.position;
        var distance = direction.magnitude;
        TotalDistance = distance /2;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject == Target)
        {
            Target.gameObject.GetComponent<EnemyStat>().RemoveHealth(Damage);
            Destroy(gameObject);
        }
    }
}
