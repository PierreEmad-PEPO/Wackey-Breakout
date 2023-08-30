using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyMenu : MonoBehaviour
{
    public void HandleEasyButton()
    {
        ConfigurationUtils.Initialize(DifficultyLevel.Easy);
    }

    public void HandleMediumButton()
    {
        ConfigurationUtils.Initialize(DifficultyLevel.Medium);
    }

    public void HandleHardButton() 
    {
        ConfigurationUtils.Initialize(DifficultyLevel.Hard);
    }

    public void StartTheGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
