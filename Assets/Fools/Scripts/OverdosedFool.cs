using Unity.VisualScripting;
using UnityEngine;

public class OverdosedFool : Fool
{
    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float maxRotation = 60;

    private bool isGoingRight;
    private Quaternion startRotation;

    protected override void Start()
    {
        startRotation = transform.rotation;
        base.Start();
    }

    protected override void DoMovement()
    {
        transform.Rotate(0, (isGoingRight ? 1 : -1) * rotationSpeed * Time.deltaTime, 0);
        if(Quaternion.Angle(
            startRotation, 
            transform.rotation) 
            > maxRotation)
        { 
            isGoingRight = !isGoingRight;
        }

        base.DoMovement();
    }
}
