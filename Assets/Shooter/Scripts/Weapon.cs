using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public event Action AmmoChanged;
    public event Action<float> ReloadProgressChanged;

    [SerializeField]
    protected float fireRate = 0.1f;
    protected float fireTimer = 0f;

    public Func<string, bool> ShootInputMethod;

    public virtual int Ammo { get; }
    public virtual int MaxAmmo { get; }
    public virtual bool IsReloading { get; }
    protected void RaiseAmmoChanged()
    {
        AmmoChanged?.Invoke();
    }

    protected void RaiseReloadProgressChanged(float progress)
    {
        Debug.Log($"Progress: {progress}");
        ReloadProgressChanged?.Invoke(progress);
    }

    public abstract void Reload();

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
