using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText, finalScoreText, recordText;
    [SerializeField] GameObject gameOverWindow;

    public void UpdateScoreText()
    {
        scoreText.text = GameManager.instance.Score.ToString();
    }

    public void GameOver()
    {
        int currentScore = GameManager.instance.Score;
        int record = PlayerPrefs.GetInt("Record", 0);

        finalScoreText.text = currentScore.ToString();


        if(currentScore > record)
        {
            PlayerPrefs.SetInt("Record",currentScore);
            PlayerPrefs.Save();
            recordText.text = currentScore.ToString();
        }
        else
        {
            recordText.text = currentScore.ToString() ;
        }
        gameOverWindow.SetActive(true);

        Time.timeScale = 0;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public int GetScore()
    {
        
        return GameManager.instance.Score;
    }

   
}
