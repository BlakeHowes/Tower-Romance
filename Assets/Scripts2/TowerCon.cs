﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCon : MonoBehaviour
{
    [Header("TowerType")]
    [SerializeField]
    private bool NearOrLeastDistance;
    [TextArea]
    public string Note;
    [SerializeField]
    private bool ProjectileOrBeam;
    [TextArea]
    public string Note2;
    [SerializeField]
    private GameObject ShootOrigin;
    [SerializeField]
    private LineRenderer Beam;
    [SerializeField]
    private GameObject Projectile;
    [Header("TowerStats")]
    [SerializeField]
    private float Range;
    [SerializeField]
    private float Damage;
    [SerializeField]
    private float FireDuration;
    [SerializeField]
    private float CoolDown;

    private float ShootTimer;

    enum TowerType
    {
        Beam,
        PiercingLine,
        ProjectileStraight,
        ProjectileArc
    }

    private void Awake()
    {
        if(Beam != null)
        {
            Beam.enabled = false;
        }
    }

    //Restructure to Only Fine Enemy before shooting
    void Update()
    {
        if(ProjectileOrBeam == false)
        {
            if(NearOrLeastDistance == false)
            {
                ShootProjectile(ClosestSlime());
            }
            else
            {
                ShootProjectile(SlimeClosestToTarget());
            }
        }

        if (ProjectileOrBeam == true)
        {
            if (NearOrLeastDistance == false)
            {
                ShootBeam(ClosestSlime());
            }
            else
            {
                ShootBeam(SlimeClosestToTarget());
            }
        }
    }

    //Slime with least distance to target
    private GameObject SlimeClosestToTarget()
    {
        Collider[] Enemies = Physics.OverlapSphere(transform.position, Range);

        GameObject EnemyNearestToTarget = null;
        float nearestDistance = Mathf.Infinity;
        foreach (var Slime in Enemies)
        {
            if (Slime.gameObject.tag == "Slime")
            {
                var sqrdistance = Slime.GetComponent<EnemyCon>().ReturnDistanceRemaing();
                if (sqrdistance < nearestDistance)
                {
                    nearestDistance = sqrdistance;
                    EnemyNearestToTarget = Slime.gameObject;
                }
            }
        }
        return EnemyNearestToTarget;
    }

    //slime closest to tower
    private GameObject ClosestSlime()
    {
        Collider[] Enemies = Physics.OverlapSphere(transform.position, Range);

        GameObject EnemyNearestToTarget = null;
        float nearestDistance = Mathf.Infinity;
        foreach (var Slime in Enemies)
        {
            if (Slime.gameObject.tag == "Slime")
            {
                var sqrdistance = (transform.position - Slime.transform.position).sqrMagnitude;
                if (sqrdistance < nearestDistance)
                {
                    nearestDistance = sqrdistance;
                    EnemyNearestToTarget = Slime.gameObject;
                }
            }
        }
        return EnemyNearestToTarget;
    }


    private void ShootBeam(GameObject Enemy)
    {
        if (Enemy != null)
        {
            ShootTimer += Time.deltaTime;
            if (ShootTimer < FireDuration)
            {
                Enemy.GetComponent<EnemyStat>().RemoveHealth(Damage);
                Beam.enabled = true;
                Beam.SetPosition(0,transform.position);
                Beam.SetPosition(1, Enemy.transform.position);
            }

            if (ShootTimer > FireDuration)
            {
                Beam.enabled = false;
                if (ShootTimer > FireDuration + CoolDown)
                {
                    ShootTimer = 0;
                }
            }
        }
        else
        {
            Beam.enabled = false;
        }
    }

    private void ShootProjectile(GameObject Enemy)
    {
        if (Enemy != null)
        {
            ShootTimer += Time.deltaTime;
            if(ShootTimer > CoolDown)
            {
                //Shoot
                GameObject bullet = Instantiate(Projectile, ShootOrigin.transform.position, Quaternion.identity);
                bullet.transform.parent = null;
                bullet.GetComponent<ProjectileCon>().Shoot(Enemy);
                ShootTimer = 0f;
            }
        }
    }
}
