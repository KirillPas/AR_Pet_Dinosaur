using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Prefab;
    public Transform spawnCenter;
    public float spawnRadius = 3f;
    public float spawnInterval = 2f;
    public int maxColl = 3;
    public int maxForWins = 12;

    private float timer;
    private List<GameObject> active = new List<GameObject>();
    private int Count = 0;
    private bool fCount = false;

    void Start()
    {
        timer = spawnInterval;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        active.RemoveAll(enemy => enemy == null);

        if (timer <= 0f && active.Count < maxColl && fCount == false)
        {
            timer = spawnInterval;
            Spawn();
            timer = spawnInterval;
        }
    }
    void Spawn()
    {
        Vector2 circlePos = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPos = new Vector3(spawnCenter.position.x + circlePos.x, spawnCenter.position.y, spawnCenter.position.z + circlePos.y);
        GameObject newEnemy = Instantiate(Prefab, spawnPos, Quaternion.identity);
        active.Add(newEnemy);
        Count++;
        if (Count >= maxForWins)
        {
            fCount = true;
        }
    }
}
