using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCon : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float Damage;
    private Rigidbody rb;
    private GameObject Target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Shoot(GameObject target)
    {
        transform.LookAt(target.transform.position);
        rb.velocity = transform.forward * speed;
        Target = target;
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
