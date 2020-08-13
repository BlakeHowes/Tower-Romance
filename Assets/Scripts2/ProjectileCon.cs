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
    private float arcDegrees;
    private Rigidbody rb;
    private GameObject Target;

    private float TotalDistance;
    public bool Arc = false;
    [SerializeField]
    private float ArcChange;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ShootProjectileStraight(GameObject target)
    {
        transform.LookAt(target.transform.position);
        rb.velocity = transform.forward * speed;
        Target = target;

        /*
        var direction = Target.transform.position - transform.position;
        var distance = direction.magnitude;
        TotalDistance = distance /2;
        */
    }

    public void ShootProjectileArc(GameObject target)
    {
        Arc = true;
        Target = target;

        var direction = Target.transform.position - transform.position;
        var distance = direction.magnitude;
        TotalDistance = distance;
        ArcChange = (distance);
    }

    private void FixedUpdate()
    {
        if(Target != null)
        {
            if (Arc == true)
            {
                ArcChange -= (TotalDistance/40);
                if (ArcChange < 0)
                {
                    ArcChange = 0f;
                }

                Vector3 DirectionAndArc = new Vector3(0, ArcChange, 0);
                transform.LookAt(Target.transform.position + DirectionAndArc);
                rb.velocity = transform.forward * speed;
            }
        }
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
