using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    private float startTime;
    private bool isRunning = true;

    public float LevelTime => Time.time - startTime;

    void Start()
    {
        KillManager.Instance.RestartKill();
        startTime = Time.time;
        isRunning = true;
    }
    void Update()
    {
        if (!isRunning) return;
    }
    public void StopTimer()
    {
        isRunning = false;
    }
    public void FinishWin()
    {
        isRunning = false;
        float t = Time.time - startTime;
        KillManager.Instance.SaveWinTime(t);
    }
    public void FinishLose()
    {
        isRunning = false;
        float t = Time.time - startTime;
        KillManager.Instance.SaveLoseTime(t);
    }
}
