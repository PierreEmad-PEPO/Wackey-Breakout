using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreMenu : MonoBehaviour
{
    private int easyHighScore; 
    private int mediumHighScore; 
    private int hardHighScore;

    [SerializeField] private Text easyText;
    [SerializeField] private Text mediumText;
    [SerializeField] private Text hardText;

    // Start is called before the first frame update
    void Start()
    {
        easyHighScore = PlayerPrefs.GetInt("EasyHighScore", 0);
        mediumHighScore = PlayerPrefs.GetInt("MediumHighScore", 0);
        hardHighScore = PlayerPrefs.GetInt("HardHighScore", 0);

        easyText.text = "Easy High Score: " + easyHighScore.ToString();
        mediumText.text = "Medium High Score: " + mediumHighScore.ToString();
        hardText.text = "Hard High Score: " + hardHighScore.ToString();
    }

    public void HandleCancelButton()
    {
        MenuManager.GoToMenu(MenuName.Main);
        Destroy(gameObject);
    }

}
