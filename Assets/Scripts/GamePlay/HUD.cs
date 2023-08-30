using System;
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

    public static int Score { get { return score; } }

    
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
        if (GameObject.Find("YouWin(Clone)") == null)
        {
            ballsRemaining--;
            ballsRemainingText.text = BallsRemainingPrefix + ballsRemaining.ToString();
        }

        if (ballsRemaining == 0)
        {
            AudioManager.Play(AudioClipName.GameOver);

            if (ConfigurationUtils.difficultyLevel == DifficultyLevel.Easy)
            {
                int mx = Math.Max(HUD.Score, PlayerPrefs.GetInt("EasyHighScore", 0));
                PlayerPrefs.SetInt("EasyHighScore", mx);
            }
            else if (ConfigurationUtils.difficultyLevel == DifficultyLevel.Medium)
            {
                int mx = Math.Max(HUD.Score, PlayerPrefs.GetInt("MediumHighScore", 0));
                PlayerPrefs.SetInt("MediumHighScore", mx);
            }
            else if (ConfigurationUtils.difficultyLevel == DifficultyLevel.Hard)
            {
                int mx = Math.Max(HUD.Score, PlayerPrefs.GetInt("HardHighScore", 0));
                PlayerPrefs.SetInt("HardHighScore", mx);
            }

            PlayerPrefs.Save();

            Instantiate(Resources.Load("GameOver"));
            Time.timeScale = 0f;
        }
    }

    private static void AddScore(int toAddscore)
    {
        score += toAddscore;
        scoreText.text = ScorePrefix + score.ToString();
    }
}
