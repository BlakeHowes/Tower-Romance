using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCon : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField]
    private TowerType TypeOfTower = TowerType.Beam;
    [SerializeField]
    private Targeting WhoToTarget = Targeting.Front;
    [Header("TowerStats")]
    [SerializeField]
    private float Range;
    [SerializeField]
    private float Damage;
    [SerializeField]
    private float FireDuration;
    [SerializeField]
    private float CoolDown;
    [Header("Acessories")]
    [SerializeField]
    private GameObject ShootOrigin;
    [SerializeField]
    private LineRenderer Beam;
    [SerializeField]
    private GameObject Projectile;
    [SerializeField]
    private GameObject GunModel;
    private float ShootTimer;
    private GameObject CurrentTarget;
    private GameObject bullet;

    enum TowerType
    {
        Beam,
        PiercingLine,
        ProjectileStraight,
        ProjectileArc
    }

    enum Targeting
    {
        Front,
        Nearest,
        HighestHealth
    }

    private void Awake()
    {
        if(Beam != null)
        {
            Beam.enabled = false;
        }
    }

    //Shoots tower currently selected in TowerType enum
    private void ShootTowerType()
    {
        switch (TypeOfTower)
        {
            case TowerType.Beam:
                ShootBeam();
                break;
            case TowerType.PiercingLine:
                //add this
                break;
            case TowerType.ProjectileStraight:
                ShootProjectileStraight();
                break;
            case TowerType.ProjectileArc:
                ShootProjectileArc();
                break;
        }
    }

    //Switches between different targets
    private GameObject FindTarget()
    {
        switch (WhoToTarget)
        {
            case Targeting.Front:
                return SlimeClosestToTarget();
            case Targeting.Nearest:
                return ClosestSlime();
            case Targeting.HighestHealth:
                return null; // change to highest health
            default:
                return null;
        }
    }

    private bool CheckIfEnemysAreInRange()
    {
        LayerMask layermask = LayerMask.GetMask("Slime");
        Collider[] Enemies = Physics.OverlapSphere(transform.position, Range, layermask);
        if (Enemies.Length > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //ShowVisual Turret Range
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    private void Update()
    {
        if(CheckIfEnemysAreInRange() == true)
        {
            ShootTowerType();
        }
        else
        {
            if(Beam != null)
            {
                Beam.enabled = false;
            }
        }

    }

    //Slime with least distance to target (Front)
    private GameObject SlimeClosestToTarget()
    {
        LayerMask layermask = LayerMask.GetMask("Slime");
        Collider[] Enemies = Physics.OverlapSphere(transform.position, Range, layermask);

        GameObject EnemyNearestToTarget = null;
        float nearestDistance = Mathf.Infinity;
        foreach (var Slime in Enemies)
        {
            var sqrdistance = Slime.GetComponent<EnemyCon>().ReturnDistanceRemaing();
            if (sqrdistance < nearestDistance)
            {
                nearestDistance = sqrdistance;
                EnemyNearestToTarget = Slime.gameObject;
            }
        }
        return EnemyNearestToTarget;
    }

    //slime closest to tower (Nearest)
    private GameObject ClosestSlime()
    {
        LayerMask layermask = LayerMask.GetMask("Slime");
        Collider[] Enemies = Physics.OverlapSphere(transform.position, Range, layermask);

        GameObject EnemyNearestToTarget = null;
        float nearestDistance = Mathf.Infinity;
        foreach (var Slime in Enemies)
        {
            var sqrdistance = (transform.position - Slime.transform.position).sqrMagnitude;
            if (sqrdistance < nearestDistance)
            {
                nearestDistance = sqrdistance;
                EnemyNearestToTarget = Slime.gameObject;
            }
        }
        return EnemyNearestToTarget;
    }

    //SingleLineRenderBeam (Beam)
    private void ShootBeam()
    {
        ShootTimer += Time.deltaTime;

        if (ShootTimer < FireDuration)
        {
            var Enemy = FindTarget();

            Enemy.GetComponent<EnemyStat>().RemoveHealth(Damage);
            Beam.enabled = true;
            Beam.SetPosition(0, ShootOrigin.transform.position);
            Beam.SetPosition(1, Enemy.transform.position);
        }

        if (ShootTimer > FireDuration)
        {
            Beam.enabled = false;
            if (ShootTimer > FireDuration + CoolDown)
            {
                ShootTimer = 0;

                ShootTowerType();
            }
        }
    }

    //Single striaght projectile (ProjectileStraight)
    private void ShootProjectileStraight()
    {
        ShootTimer += Time.deltaTime;
        if (ShootTimer > CoolDown)
        {
            var Enemy = FindTarget();
            //Shoot
            GameObject bullet = Instantiate(Projectile, ShootOrigin.transform.position, Quaternion.identity);
            bullet.transform.parent = null;
            bullet.GetComponent<ProjectileCon>().ShootProjectileStraight(Enemy);
            ShootTimer = 0f;

            if (GunModel != null)
            {
                if (FindTarget() != null)
                {
                    GunModel.transform.LookAt(FindTarget().transform, Vector3.up);
                }
            }
        }
    }

    private void ShootProjectileArc()
    {
        ShootTimer += Time.deltaTime;
        if (ShootTimer > CoolDown)
        {
            var Enemy = FindTarget();
            //Shoot
            bullet = Instantiate(Projectile, ShootOrigin.transform.position, Quaternion.identity);
            bullet.transform.parent = null;
            bullet.GetComponent<ProjectileCon>().ShootProjectileArc(Enemy);
            ShootTimer = 0f;
        }
    }

    private void ShootBeamSingleShot()
    {

    }
}
