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

    // Start is called before the first frame update
    protected virtual void Start()
    {
        remainingBlocks = 39;
        EventManager.AddOnBlockDestroyedInvoker(this);
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

        onBlockDestroyed.Invoke(blockPoints);

        remainingBlocks--;

        Debug.Log(remainingBlocks);

        if (remainingBlocks == 0)
        {
            AudioManager.Play(AudioClipName.YouWin);

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
        }

        Destroy(gameObject);
    }

    protected virtual void OnBecameInvisible()
    {
        EventManager.RemoveOnBlockDestroyedInvoker(this);
    }
}
