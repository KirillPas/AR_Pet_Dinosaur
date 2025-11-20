using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;   // Префаб врага для спавна
    [SerializeField] public Transform player;         // Трансформ игрока
    [SerializeField] private float spawnDistance = 1f; // Расстояние от игрока для спавна врага
    private bool hasSpawned = false;                    // Флаг спавна, чтобы враг создавался один раз
    void SpawnEnemyNearPlayer()
    {
        Vector3 spawnPosition = player.position + Random.insideUnitSphere * spawnDistance;
        spawnPosition.y = player.position.y;

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        EnemyMove enemyMove = enemy.GetComponent<EnemyMove>();
        if (enemyMove != null)
        {
            enemyMove.SetPlayer(player);
        }

        hasSpawned = true;
    }
    void Update()
    {
        if (!hasSpawned)
        {
            SpawnEnemyNearPlayer();
        }
    }
}
