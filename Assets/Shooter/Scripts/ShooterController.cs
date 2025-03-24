using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    public event Action<Weapon, Weapon> WeaponChanged;

    List<Weapon> weapons;
    Weapon currentWeapon;
    public Weapon CurrentWeapon => currentWeapon;

    void Start()
    {
        weapons = GetComponentsInChildren<Weapon>(true).ToList();
        weapons.ForEach(w => w.gameObject.SetActive(false));
        ChangeWeapon(weapons.First());
    }

    void Update()
    {
        if(currentWeapon.ShootInputMethod("Fire1"))
        {
            currentWeapon.Attack();
        }

        if (Input.GetButtonDown("Reload"))
        {
            Debug.Log("Jsem tu!");
            currentWeapon.Reload();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangeWeapon(weapons.ElementAt(0));

        if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeWeapon(weapons.ElementAt(1));

        if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangeWeapon(weapons.ElementAt(2));
    }

    private void ChangeWeapon(Weapon newWeapon)
    {
        if(currentWeapon)
        {
            if (currentWeapon.IsReloading)
                currentWeapon.Reload();
            currentWeapon.gameObject.SetActive(false);
        }

        WeaponChanged?.Invoke(currentWeapon, newWeapon);

        currentWeapon = newWeapon;
        currentWeapon.gameObject.SetActive(true);
    }
}
