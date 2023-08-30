using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{

    public static void GoToMenu(MenuName menuName)
    {
        switch (menuName) 
        {
            case MenuName.Main:
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.Difficulty:
                SceneManager.LoadScene("DifficultyMenu");
                break;
            case MenuName.HighScore:
                GameObject.Find("MainMenuCanvas").SetActive(false);
                Object.Instantiate(Resources.Load("HighScoreCanvas"));
                break;
            case MenuName.Pause:
                Time.timeScale = 0f;
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
        }
    }
}
