using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] public Transform player;
    [SerializeField] private float spawnDistance = 1f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundOffset = 0f;

    private bool hasSpawned = false;
    public void SpawnEnemyNearPlayer()
    {
        if (hasSpawned)
            return;

        if (player == null || enemyPrefab == null)
        {
            Debug.LogWarning("Player or enemyPrefab not assigned!");
            return;
        }

        Vector3 spawnPosition = player.position + player.forward * spawnDistance;

        if (Physics.Raycast(spawnPosition + Vector3.up, Vector3.down, out RaycastHit hit, 10f, groundLayer))
        {
            spawnPosition.y = hit.point.y + groundOffset;
        }
        else
        {
            spawnPosition.y = player.position.y;
        }
        Instantiate(enemyPrefab, spawnPosition, Quaternion.LookRotation(player.forward));
        hasSpawned = true;
    }
}