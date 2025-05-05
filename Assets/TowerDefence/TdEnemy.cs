using UnityEngine;

public class TdEnemy : MonoBehaviour
{
    Rigidbody2D rb;
    Transform target = null;

    [SerializeField]
    private float speed = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(!target)
        {
            target = TdWaypointProvider.Instance.GetNext(null);
        }

        var dir = target.position - transform.position;
        dir.Normalize();

        rb.MovePosition(transform.position + dir * speed * Time.fixedDeltaTime);
        
        if(Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            target = TdWaypointProvider.Instance.GetNext(target);
        }
    }
}
