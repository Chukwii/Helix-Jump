using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int best;
    public int score;
    public int coins;

    public int currentStage = 0;

    public static GameManager singleton;
    public GameObject ball, tutorialPanel;


    // Start is called before the first frame update
    void Awake()
    {
        if (singleton == null)
            singleton = this;
        else if (singleton != this)
            Destroy(gameObject);

        best = PlayerPrefs.GetInt("HighScore");
        coins = PlayerPrefs.GetInt("TotalCoins");
        currentStage =  PlayerPrefs.GetInt("lastStage");

        UIManager.displayLevel = currentStage + 1;
    }

    void Update()
    {
        PlayerPrefs.SetInt("TotalCoins", coins);
    }

    public void NextLevel()
    {
        if(PlayerPrefs.GetInt("lastStage") >= 50)
        {
            currentStage = 0;
            UIManager.displayLevel = 1;
        }
        else
        {
            currentStage++;
            UIManager.displayLevel++;
        }
        
        GameObject ball;
        ball = GameObject.FindGameObjectWithTag("Player");
        ball.GetComponent<BallController>().ResetBall();
        FindObjectOfType<HelixController>().LoadStage(currentStage);
        FindObjectOfType<coinSpawn>().spawnCoins();

        if ((currentStage - 1) == PlayerPrefs.GetInt("lastStage"))
            PlayerPrefs.SetInt("lastStage", currentStage);
        Debug.Log("Next level>");
    }

    public void PreviousLevel()
    {
        currentStage--;
        UIManager.displayLevel--;
        GameObject ball;
        ball = GameObject.FindGameObjectWithTag("Player");
        ball.GetComponent<BallController>().ResetBall();

        FindObjectOfType<HelixController>().LoadStage(currentStage);
        FindObjectOfType<coinSpawn>().spawnCoins();

        //PlayerPrefs.SetInt("TotalCoins", coins);
        //PlayerPrefs.SetInt("lastStage", currentStage);
        Debug.Log("previous level<");
    }

    public void RestartLevel()
    {
        Debug.Log("GameOver");
        //Show ads
        singleton.score = 0;

        FindObjectOfType<BallController>().ResetBall();
        FindObjectOfType<HelixController>().LoadStage(currentStage);
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;

        if(score > best)
        {
            best = score;
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
