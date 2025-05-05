using System;
using UnityEngine;

public class ShooterTargetSpawner : MonoBehaviour
{
    public event Action<int> PointsChanged;

    [SerializeField]
    private ShooterTarget targetPrefab;

    private int points;

    private ShooterTarget currentTarget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnTarget();
    }

    void AddPoints(int amt)
    {
        points += amt;
        PointsChanged?.Invoke(points);
    }

    private void SpawnTarget()
    {
        currentTarget = Instantiate(targetPrefab, transform.position, Quaternion.identity);
        currentTarget.Destroyed += OnTargetDestroyed;
    }

    private void OnTargetDestroyed()
    {
        currentTarget.Destroyed -= OnTargetDestroyed;
        AddPoints(1);
        SpawnTarget();
    }
}
