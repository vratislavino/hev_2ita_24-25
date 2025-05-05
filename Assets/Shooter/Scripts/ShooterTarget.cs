using System;
using UnityEngine;

public class ShooterTarget : MonoBehaviour
{
    bool isDestroyed = false;
    public event Action Destroyed;

    private void OnCollisionEnter(Collision collision)
    {
        if (isDestroyed)
            return;
        isDestroyed = true;
        Destroyed?.Invoke();
        Destroy(gameObject);
    }
}
