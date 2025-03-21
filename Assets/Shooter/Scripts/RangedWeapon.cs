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

    [SerializeField]
    protected Rigidbody bulletPrefab;

    [SerializeField]
    protected float bulletSpeed;

    [SerializeField]
    protected Transform firePoint;

    protected virtual void Start()
    {
        currentAmmo = maxAmmo;
        ShootInputMethod = Input.GetButtonDown;
    }

    public void Reload()
    {

    }

    public void Shoot()
    {
        currentAmmo--;
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
