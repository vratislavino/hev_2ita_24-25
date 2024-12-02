using UnityEngine;

public class MagicFool : Fool
{
    public override void Hit()
    {
        transform.Rotate(Vector3.up, 180f);
        Vector3 pos = transform.localPosition;
        pos.z = -pos.z;
        pos.x = -pos.x;
        transform.localPosition = pos;

        base.Hit();
    }
}
