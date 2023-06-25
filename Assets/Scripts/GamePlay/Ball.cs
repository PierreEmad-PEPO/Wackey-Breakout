using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float totalTime = 10f;
    private float elapsedTime = 0f;
    private Timer idleTimer;
    private Vector2 force;
    private static Timer spawnDelay;


    // Start is called before the first frame update
    void Start()
    {
        totalTime = ConfigurationUtils.BallLifeTime;

        idleTimer = gameObject.AddComponent<Timer>();
        idleTimer.Duration = 1.2f;
        idleTimer.Run();
        float angle = Random.Range(240f, 300f) * Mathf.Deg2Rad;
        force = new Vector2 (Mathf.Cos(angle), Mathf.Sin(angle));

        spawnDelay = gameObject.AddComponent<Timer>();
        spawnDelay.Duration = 1f;
        spawnDelay.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (idleTimer.Finished)
        {
            GetComponent<Rigidbody2D>().AddForce(force * ConfigurationUtils.BallImpulseForce, ForceMode2D.Impulse);
            idleTimer.Stop();
        }


        if (elapsedTime < totalTime) elapsedTime += Time.deltaTime;
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        if (transform.position.y < ScreenUtils.ScreenBottom && spawnDelay.Finished)
        {
            Camera.main.GetComponent<BallSpawner>().SpawnBall();
            spawnDelay.Run();
        }

        if (transform.position.y < ScreenUtils.ScreenBottom)
            HUD.LoseBall();
        
        Destroy(gameObject);
    }
}
