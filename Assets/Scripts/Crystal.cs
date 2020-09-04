using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    private float timer;
    public float speed;

    public float Xspeed;
    public float Yspeed;
    public float Zspeed;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer > speed / 2)
        {
            Vector3 poschange = new Vector3(0f, 0.001f, 0f);
            transform.position -= poschange;
        }
        else
        {
            Vector3 poschange = new Vector3(0f, 0.001f, 0f);
            transform.position += poschange;
        }

        if(timer > speed)
        {
            timer = 0f;
        }
        transform.Rotate((1f * Xspeed) * Time.deltaTime, (1f * Yspeed) * Time.deltaTime, (1f * Zspeed) * Time.deltaTime);
    }
}
