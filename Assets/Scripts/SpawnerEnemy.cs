using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerEnemy : MonoBehaviour
{
    public GameObject Prefab;
    public Transform spawnCenter;
    public float spawnRadius = 3f;
    public float spawnInterval = 3f;
    public int maxColl = 3;
    public int maxForWins = 12;
    public LevelTimer levelTimer;

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
            SpawnEnemy();
            timer = spawnInterval;
        }
        if (Count == maxForWins && active.Count == 0)
        {
            levelTimer.StopTimer();
            float time = levelTimer.LevelTime;
            KillManager.Instance.SaveLevelTime(time);
            DeathCanvas.previousSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("Win");
        }
    }
    void SpawnEnemy()
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