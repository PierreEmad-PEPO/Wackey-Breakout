using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private const string ScorePrefix = "Score: ";
    private const string BallsRemainingPrefix = "Balls Remaining: ";

    [SerializeField] Text scoreObject;
    [SerializeField] Text ballsRemainingObject;

    private static Text scoreText;
    private static Text ballsRemainingText;

    private static int score = 0;
    private static int ballsRemaining = 5;

    
    // Start is called before the first frame update
    void Start()
    {
        ballsRemaining = ConfigurationUtils.BallsNumberPerGame;
        scoreText = scoreObject;
        ballsRemainingText = ballsRemainingObject;


        scoreText.text = ScorePrefix + score.ToString();
        ballsRemainingText.text = BallsRemainingPrefix + ballsRemaining.ToString();

        EventManager.AddOnBallLostListener(LoseBall);
        EventManager.AddOnBlockDestroyedListener(AddScore);
    }


    private static void LoseBall()
    {
        ballsRemaining--;
        ballsRemainingText.text = BallsRemainingPrefix + ballsRemaining.ToString();
    }

    private static void AddScore(int toAddscore)
    {
        score += toAddscore;
        scoreText.text = ScorePrefix + score.ToString();
    }
}
