using UnityEngine;

public class ShooterController : MonoBehaviour
{
    Weapon currentWeapon;

    void Start()
    {
        currentWeapon = GetComponentInChildren<Weapon>();
    }

    void Update()
    {
        if(currentWeapon.ShootInputMethod("Fire1"))
        {
            currentWeapon.Attack();
        }
    }
}
