using UnityEngine;

public class Custom90Fool : Fool
{
    public float multiplier;

    public override void Hit()
    {
        speed *= multiplier;
        base.Hit();
    }
}
