using UnityEngine;

public class RangedWeapon : Weapon
{
    // TODO :
    // ShooterController -> Inputs
    // Colt -> Specific class

    [SerializeField]
    protected int maxAmmo = 7;
    protected int currentAmmo;

    [SerializeField]
    protected Rigidbody bulletPrefab;

    [SerializeField]
    protected float bulletSpeed;

    [SerializeField]
    protected Transform firePoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentAmmo = maxAmmo;
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

    protected void DoShoot() {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.AddForce(bullet.transform.forward * bulletSpeed, ForceMode.Impulse);
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
