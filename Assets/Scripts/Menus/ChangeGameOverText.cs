using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeGameOverText : MonoBehaviour
{
    [SerializeField] Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (ConfigurationUtils.difficultyLevel == DifficultyLevel.Easy)
        {
            scoreText.text = "Your Easy High Score is " + PlayerPrefs.GetInt("EasyHighScore");
        }
        else if (ConfigurationUtils.difficultyLevel == DifficultyLevel.Medium)
        {
            scoreText.text = "Your Medium High Score is " + PlayerPrefs.GetInt("MediumHighScore");
        }
        else if (ConfigurationUtils.difficultyLevel == DifficultyLevel.Hard)
        {
            scoreText.text = "Your Hard High Score is " + PlayerPrefs.GetInt("HardHighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
