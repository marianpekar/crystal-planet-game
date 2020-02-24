using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    [SerializeField]
    Text display;

    Stopwatch stopwatch = new Stopwatch();

    // Start is called before the first frame update
    void Start()
    {
        Run();
        PlayerEvents.Instance.OnPlayerDied.Add(Stop);
        PlayerEvents.Instance.OnPlayerRespawned.Add(Restart);
    }

    void Run()
    {
        stopwatch.Start();
    }

    void Restart()
    {
        stopwatch.Restart();
    }

    void Stop()
    {
        stopwatch.Stop();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (stopwatch.IsRunning)
            display.text = stopwatch.ElapsedMilliseconds.ToString();
    }
}
