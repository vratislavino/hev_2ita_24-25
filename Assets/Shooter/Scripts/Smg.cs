using UnityEngine;

public class Smg : RangedWeapon
{
    protected override void Start()
    {
        base.Start();
        ShootInputMethod = Input.GetButton;
    }
}
