using System;
using UnityEngine;

public abstract class Fool : MonoBehaviour
{
    public event Action<Fool> Died;
    public int Value;

    [SerializeField]
    protected float speed;

    [SerializeField]
    protected int maxLives;
    protected int currentLives;

    protected virtual void Start()
    {
        currentLives = maxLives;
    }

    void Update()
    {
        DoMovement();
    }

    public virtual void Hit()
    {
        DoDamage();
    }

    protected void DoDamage()
    {
        currentLives--;
        if(currentLives <= 0)
        {
            Died?.Invoke(this);
            Destroy(gameObject);
        }
    }

    protected virtual void DoMovement()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
