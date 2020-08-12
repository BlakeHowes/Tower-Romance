using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    [SerializeField]
    private float Health;

    void Update()
    {
        if (Health < 0f)
        {
            Destroy(gameObject);
        }
    }

    public void RemoveHealth(float Damage)
    {
        Health -= Damage;
    }
}
