using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    protected static int remainingBlocks;
    protected int blockPoints = 5;
    protected event UnityAction<int> onBlockDestroyed;
    protected static event UnityAction onYouWin;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        remainingBlocks = 39;
        EventManager.AddOnBlockDestroyedInvoker(this);
        EventManager.AddOnYouWinInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddOnBlockDestroyedEventListener(UnityAction<int> action)
    {
        onBlockDestroyed += action;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.Play(AudioClipName.DestroyBrick);

        remainingBlocks--;

        Debug.Log(remainingBlocks);

        if (remainingBlocks == 0)
        {
            AudioManager.Play(AudioClipName.YouWin);

            onYouWin.Invoke();

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

            Instantiate(Resources.Load("YouWin"));

            onBlockDestroyed.Invoke(blockPoints);
        }

        Destroy(gameObject);
    }

    protected virtual void OnBecameInvisible()
    {
        EventManager.RemoveOnBlockDestroyedInvoker(this);
    }

    public void AddOnYouWinEventListener(UnityAction action)
    {
        onYouWin += action;
    }
}
