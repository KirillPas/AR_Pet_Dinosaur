using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Transform player;
    public float speed = 3.0f;
    public void SetPlayer(Transform playerTransform)
    {
        player = playerTransform;
    }
    void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
