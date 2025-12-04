using UnityEngine;

public class KillManager : MonoBehaviour
{
    public static KillManager Instance;
    public int kills;
    public float lastWinTime;
    public float lastLoseTime;

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
    public void SaveWinTime(float time)
    {
        lastWinTime = time;
    }

    public void SaveLoseTime(float time)
    {
        lastLoseTime = time;
    }
    public void RestartKill()
    {
        kills = 0;
        lastWinTime = 0f;
        lastLoseTime = 0f;
    }
}
