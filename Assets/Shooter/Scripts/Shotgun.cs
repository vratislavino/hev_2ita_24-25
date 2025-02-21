using UnityEngine;

public class Shotgun : RangedWeapon
{
    [SerializeField]
    private int pellets = 50;

    [SerializeField]
    private float spread = 0.5f;

    protected override void DoShoot()
    {
        for(int i = 0; i < pellets; i++)
        {
            var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            
            Vector3 velocity = bullet.transform.forward;
            velocity += Random.insideUnitSphere * spread;

            bullet.AddForce(velocity * bulletSpeed, ForceMode.Impulse);

            Destroy(bullet.gameObject, 3f);
        }
    }
}
