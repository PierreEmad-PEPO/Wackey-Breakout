using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    private Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = Random.Range(ConfigurationUtils.SpawnNextBallTimeMin, ConfigurationUtils.SpawnNextBallTimeMax+1);
        timer.AddOnTimerFinishedListener(TimerListener);
        timer.Run();

        SpawnBall();

        EventManager.AddOnBallDieListener(SpawnBall);
    }

    void TimerListener()
    {
        SpawnBall();
        timer.Duration = Random.Range(ConfigurationUtils.SpawnNextBallTimeMin, ConfigurationUtils.SpawnNextBallTimeMax + 1);
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnBall()
    {
        float x = Random.Range(ScreenUtils.ScreenLeft + 3, ScreenUtils.ScreenRight - 3);
        float y = Random.Range(-3f, 0.5f);
        Vector2 p1 = new Vector2(x - 0.5f, y - 0.5f);
        Vector2 p2 = new Vector2(x + 0.5f, y + 0.5f);
        if (Physics2D.OverlapArea(p1, p2) == null)
        {
            Instantiate<GameObject>(ball, new Vector2(x, y), Quaternion.identity);
        }
    }
}
