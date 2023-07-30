using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    private float totalTime = 10f;
    private float elapsedTime = 0f;
    private Timer idleTimer;
    private Vector2 force;
    private static Timer spawnDelay;
    private SpriteRenderer spriteRenderer;
    private event UnityAction onBallDieEvent;
    private event UnityAction onBallLostEvent;



    // Start is called before the first frame update
    void Start()
    {
        totalTime = ConfigurationUtils.BallLifeTime;

        idleTimer = gameObject.AddComponent<Timer>();
        idleTimer.Duration = 1.2f;
        idleTimer.AddOnTimerFinishedListener(StartMoving);
        idleTimer.Run();

        float angle = Random.Range(240f, 300f) * Mathf.Deg2Rad;
        force = new Vector2 (Mathf.Cos(angle), Mathf.Sin(angle));

        spawnDelay = gameObject.AddComponent<Timer>();
        spawnDelay.Duration = 1f;
        spawnDelay.Run();

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        EventManager.AddOnBallDieInvoker(this);
        EventManager.AddOnBallLostInvoker(this);
    }

    void StartMoving()
    {
        GetComponent<Rigidbody2D>().AddForce(force * ConfigurationUtils.BallImpulseForce, ForceMode2D.Impulse);
        idleTimer.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime < totalTime) elapsedTime += Time.deltaTime;
        else
        {
            Destroy(gameObject);
        }

        Color newColor = spriteRenderer.color;
        newColor.a = 1 - elapsedTime / totalTime;
        spriteRenderer.color = newColor;
    }

    private void OnBecameInvisible()
    {
        if (transform.position.y < ScreenUtils.ScreenBottom && spawnDelay.Finished)
        {
            onBallDieEvent.Invoke();
            spawnDelay.Run();
        }

        if (transform.position.y < ScreenUtils.ScreenBottom)
            onBallLostEvent.Invoke();

        EventManager.RemoveOnBallDieInvoker(this);

        Destroy(gameObject);
    }

    public void AddOnBallDieEventListener(UnityAction action)
    {
        onBallDieEvent += action;
    }

    public void AddOnBallLostEventListener(UnityAction action) 
    {
        onBallLostEvent += action;
    }
}
