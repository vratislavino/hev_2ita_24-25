using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [Header("Weapon")]
    [SerializeField]
    private TMP_Text weaponName;

    [SerializeField]
    private TMP_Text ammo;

    [SerializeField]
    private Image weaponImage;

    [Space(20)]
    [Header("Crosshair")]
    [SerializeField]
    private GameObject normalCrosshair;

    [SerializeField]
    private GameObject reloadCrosshair;

    [SerializeField]
    private Image reloadCircle;

    [Space(20)]
    [SerializeField]
    private ShooterController shooterController;

    void Awake()
    {
        shooterController.WeaponChanged += OnWeaponChanged;
        normalCrosshair.SetActive(true);
        reloadCrosshair.SetActive(false);
    }

    private void OnWeaponChanged(Weapon oldW, Weapon newW)
    {
        if (oldW)
        {
            oldW.AmmoChanged -= OnAmmoChanged;
            oldW.ReloadProgressChanged -= OnReloadProgressChanged;
        }
        newW.AmmoChanged += OnAmmoChanged;
        newW.ReloadProgressChanged += OnReloadProgressChanged;
        normalCrosshair.SetActive(!newW.IsReloading);
        reloadCrosshair.SetActive(newW.IsReloading);


        weaponName.text = newW.name;
        weaponImage.sprite = null;
        ChangeCurrentAmmo(newW);
    }

    private void OnReloadProgressChanged(float progress)
    {
        if(progress <= 0) // konec pøebíjení
        {
            normalCrosshair.SetActive(true);
            reloadCrosshair.SetActive(false);
        } else
        {
            if(progress > 0.9999f) // zaèátek pøebíjení
            {
                normalCrosshair.SetActive(false);
                reloadCrosshair.SetActive(true);
            }
            reloadCircle.fillAmount = progress;
        }
    }

    private void ChangeCurrentAmmo(Weapon w) {
        ammo.text = $"{w.Ammo}/{w.MaxAmmo}";
    }

    private void OnAmmoChanged()
    {
        ChangeCurrentAmmo(shooterController.CurrentWeapon);
    }
}
