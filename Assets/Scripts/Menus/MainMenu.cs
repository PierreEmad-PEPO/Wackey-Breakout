using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void HandleStartGameButton()
    {
        MenuManager.GoToMenu(MenuName.Difficulty);
    }

    public void HandleHighScoreButton()
    {
        MenuManager.GoToMenu(MenuName.HighScore);
    }

    public void HandleExitButton()
    {
        Application.Quit();
    }
}
