using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void HandleResumeButton()
    {
        Time.timeScale = 1.0f;
        Destroy(gameObject);
    }

    public void HandleMainMenuButton()
    {
        Time.timeScale = 1.0f;
        MenuManager.GoToMenu(MenuName.Main);
        Destroy(gameObject);
    }
}
