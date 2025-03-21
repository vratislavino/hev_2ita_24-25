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
    [SerializeField]
    private ShooterController shooterController;

    void Awake()
    {
        shooterController.WeaponChanged += OnWeaponChanged;
    }

    private void OnWeaponChanged(Weapon oldW, Weapon newW)
    {
        weaponName.text = newW.name;
        weaponImage.sprite = null;
        ammo.text = $"{newW.Ammo}/{newW.MaxAmmo}";
    }
}
