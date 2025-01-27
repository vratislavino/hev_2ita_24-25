using UnityEngine;
using UnityEngine.AI;

public class RPSEnemySpawner : MonoBehaviour
{
    [SerializeField]
    private int enemiesCount = 10;

    [SerializeField]
    private RPSSymbol enemyPrefab;

    void Start()
    {
        SpawnEnemies(enemiesCount);
    }

    private void SpawnEnemies(int enemiesCount)
    {
        for(int i = 0; i < enemiesCount; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        var spawnPosition = GetRandomPosition();
        var enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemy.transform.parent = transform;
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 pos = new Vector3(
            Random.Range(0,100),
            100f,
            Random.Range(0, 100)
            );

        if (Physics.Raycast(pos, Vector3.down, out RaycastHit hit, 105f))
        {
            if(hit.collider.name.Contains("Terrain"))
            {
                return hit.point;
            } else
            {
                return GetRandomPosition();
            }
        } else
        {
            return GetRandomPosition();
        }
    }
}
