using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float halfWidth;
    private const float BounceAngleHalfRange = 60f;
    private Timer effectTimer;
    private float paddleMoveUnitsPerSecond;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        halfWidth = GetComponent<BoxCollider2D>().size.x/2f;
        paddleMoveUnitsPerSecond = ConfigurationUtils.PaddleMoveUnitsPerSecond;
        effectTimer = gameObject.AddComponent<Timer>();
        EventManager.AddOnSpeedActivateListener(AddSpeed);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.GoToMenu(MenuName.Pause);
        }
    }

    void AddSpeed(int duration, int extraSpeed)
    {
        float ratio = ((float)extraSpeed / 100f) + 1f;
        paddleMoveUnitsPerSecond *= ratio;
        effectTimer.Duration = duration;
        effectTimer.Run();
        effectTimer.AddOnTimerFinishedListener(UndoEffect);
    }

    void UndoEffect()
    {
        paddleMoveUnitsPerSecond = ConfigurationUtils.PaddleMoveUnitsPerSecond;
    }

    private void FixedUpdate()
    {
        Vector2 pos = new Vector2(CalculateClampedX(), transform.position.y);
        _rigidbody2D.MovePosition(pos);
    }

    private float CalculateClampedX()
    {
        float newX = transform.position.x + Input.GetAxis("Horizontal") * paddleMoveUnitsPerSecond * Time.deltaTime;

        newX = Mathf.Min(newX, ScreenUtils.ScreenRight - halfWidth);
        newX = Mathf.Max(newX, ScreenUtils.ScreenLeft + halfWidth);

        return newX;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.Play(AudioClipName.BallHitPaddle);

        ContactPoint2D[] contacts = new ContactPoint2D[2];
        collision.GetContacts(contacts);

        float y = Mathf.Abs(contacts[0].point.y - contacts[1].point.y);

        if (y < 0.05f) return;


        float dif = collision.gameObject.transform.position.x - transform.position.x;
        float angle = 90 - (dif / halfWidth) * BounceAngleHalfRange;
        angle *= Mathf.Deg2Rad;
        Vector2 force = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = force * ConfigurationUtils.BallImpulseForce;
    }
}
