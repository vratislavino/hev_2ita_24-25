using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    protected float fireRate = 0.1f;
    protected float fireTimer = 0f;

    public Func<string, bool> ShootInputMethod;

    public virtual int Ammo { get; }
    public virtual int MaxAmmo { get; }


    protected virtual void Update()
    {
        fireTimer -= Time.deltaTime;

    }

    public virtual bool CanAttack()
    {
        if (fireTimer <= 0f) 
            return true;
        return false;
    }

    public virtual void Attack()
    {
        if (!CanAttack())
            return;
    }
}
