using UnityEngine;

public class RPSCameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    Vector3 offset;

    void Start()
    {
        offset = target.position - transform.position;   
    }

    void Update()
    {
        if (target == null)
        {
            enabled = false;
            return;
        }
        transform.position = target.position - offset;
    }
}
