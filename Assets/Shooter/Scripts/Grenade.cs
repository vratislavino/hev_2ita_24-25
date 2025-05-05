using System;
using System.Collections;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Boom());
    }

    private IEnumerator Boom()
    {
        yield return new WaitForSeconds(3);

        DoEffect();

        Destroy(gameObject);
    }

    private void DoEffect()
    {
        var rbs = Physics.OverlapSphere(transform.position, 6f);
        foreach (var rb in rbs)
        {
            if (rb.TryGetComponent<Rigidbody>(out var rigidbody))
            {
                var dir = (rb.transform.position - transform.position).normalized;
                rigidbody.AddForce(dir * 10, ForceMode.Impulse);
            }
        }
    }
}
