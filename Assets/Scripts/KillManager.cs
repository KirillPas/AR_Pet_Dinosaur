using UnityEngine;

public class KillManager : MonoBehaviour
{
    public static KillManager Instance;
    public int kills;
    public float lastLevelTime;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddKill()
    {
        kills++;
    }
    public void SaveLevelTime(float time)
    {
        lastLevelTime = time;
    }
    public void RestartKill()
    {
        kills = 0;
        lastLevelTime = 0f;
    }
}
