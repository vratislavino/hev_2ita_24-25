using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField]
    private float force;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            var rb = collision.collider.GetComponentInParent<Rigidbody>();
            rb.linearVelocity += Vector3.up * force;
        }
    }
}
