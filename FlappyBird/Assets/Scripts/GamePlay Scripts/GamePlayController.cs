using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    private Bird bird;
    public Text scoreText, scoreBoardText, highScoreBoardText;
    public GameObject getReady, scoreBoard, silverMedal, goldMedal;
    private int score;
    void Awake()
    {
        bird = GameObject.FindObjectOfType<Bird>();
    }

    
    void Update()
    {
        if (bird.hasTheGameStarted)
        {
            getReady.SetActive(false);
        }
        if (bird.hasBirdDead)
        {
            scoreBoard.SetActive(true);
        }
        ScoreUpdate();
        SetTheMedal(); 


    }

    void SetTheMedal()
    {
        if(score>=5 && score < 10)
        {
            silverMedal.SetActive(true);
        }
        else if (score >= 10)
        {
            goldMedal.SetActive(true);
        }
        else
        {
            silverMedal.SetActive(false);
            goldMedal.SetActive(false);
        }
    }
    void SetNewHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
    void ScoreUpdate()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        scoreText.text = score.ToString();

        scoreBoardText.text = score.ToString();
        highScoreBoardText.text = PlayerPrefs.GetInt("HighScore",0).ToString();
        SetNewHighScore();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
