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
        finalScoreText.text = GameManager.instance.Score.ToString();
        recordText.text = PlayerPrefs.GetInt("Record").ToString();
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

    public  bool IsNewRecord()
    {
        int currentScore = GameManager.instance.Score;

        int record = PlayerPrefs.GetInt("Record", 0);
        return currentScore > record;
    }
}
