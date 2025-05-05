using UnityEngine;

public class RangedWeapon : Weapon
{
    // TODO :
    // ShooterController -> Inputs
    // Colt -> Specific class

    [SerializeField]
    protected int maxAmmo = 7;
    protected int currentAmmo;

    public override int Ammo => currentAmmo;
    public override int MaxAmmo => maxAmmo;

    public override bool IsReloading => remainingReloadTime > 0;

    [SerializeField]
    protected Rigidbody bulletPrefab;

    [SerializeField]
    protected float bulletSpeed;

    [SerializeField]
    protected Transform firePoint;

    [SerializeField]
    protected float reloadTime;
    protected float remainingReloadTime;

    protected virtual void Start()
    {
        ChangeAmmo(maxAmmo);
        ShootInputMethod = Input.GetButtonDown;
    }

    public override void Reload()
    {
        remainingReloadTime = reloadTime;
        RaiseReloadProgressChanged(1);
        Debug.Log($"Reloading {remainingReloadTime}");
    }

    protected override void Update()
    {
        base.Update();
        if(remainingReloadTime > 0)
        {
            remainingReloadTime -= Time.deltaTime;
            RaiseReloadProgressChanged(remainingReloadTime/reloadTime);
            if(remainingReloadTime <= 0)
            {
                ChangeAmmo(maxAmmo);
            }
        }
    }

    protected void ChangeAmmo(int newVal)
    {
        currentAmmo = newVal;
        RaiseAmmoChanged();
    }

    public void Shoot()
    {
        if (IsReloading)
            return;

        ChangeAmmo(currentAmmo - 1);
        if (currentAmmo == 0)
        {
            Reload();
            return;
        }
        DoShoot();
        fireTimer = fireRate;
    }

    protected virtual void DoShoot() {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.AddForce(bullet.transform.forward * bulletSpeed, ForceMode.Impulse);
    
        Destroy(bullet.gameObject, 3f);
    }

    public override void Attack()
    {
        if(CanAttack())
            Shoot();
    }

    public override bool CanAttack()
    {
        return base.CanAttack() && currentAmmo > 0;
    }
}
