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
    }
    void Update()
    {
        if (!isRunning) return;
    }
    public void StopTimer()
    {
        isRunning = false;
    }
}
