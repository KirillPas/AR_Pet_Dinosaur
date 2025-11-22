using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;  // Префаб врага для спавна
    public Transform spawnCenter;   // Трансформ, вокруг которого спавним врагов (ваш префаб)
    public float spawnRadius = 3f;  // Радиус спавна вокруг префаба
    public float spawnInterval = 2f; // Интервал между спавнами
    public int maxEnemies = 3;      // Максимум врагов

    private float timer;
    public int currentEnemyCount;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f && currentEnemyCount < maxEnemies)
        {
            SpawnEnemy();
            timer = spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        Vector2 circlePos = Random.insideUnitCircle * spawnRadius;
        // Устанавливаем позицию врага вокруг префаба по X и Z с одинаковой высотой Y
        Vector3 spawnPos = new Vector3(spawnCenter.position.x + circlePos.x, spawnCenter.position.y, spawnCenter.position.z + circlePos.y);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        currentEnemyCount++;
    }

    public void EnemyDied()
    {
        currentEnemyCount--;
    }
}