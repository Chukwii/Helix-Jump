using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GameManager : MonoBehaviour
{
    public int best;
    public int score;
    public int coins;

    public int currentStage = 0;

    public static GameManager singleton;
    public GameObject ball, newBall;

    public bool connectedToGooglePlay;

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

        if (currentStage >= 1)
        {
            newBall = Instantiate(ball, new Vector3(1.68f, 3.979f, -0.2f), ball.transform.rotation);
        }

        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
    }

    private void Start()
    {
        LogInToGooglePlay();
    }

    private void LogInToGooglePlay()
    {
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

    private void ProcessAuthentication(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {
            connectedToGooglePlay = true;
            Debug.Log("in");
        }
        else connectedToGooglePlay = false;
    }

    private void LeaderboardUpdate(bool success)
    {
        if (success) Debug.Log("Updated Leaderboard");
        else Debug.Log("Unable to update Leaderboard");
    }

    public void ShowLeaderboard()
    {
        if(!connectedToGooglePlay)
        {
            LogInToGooglePlay();
        }
        Social.ShowLeaderboardUI();
    }

    void Update()
    {
        PlayerPrefs.SetInt("TotalCoins", coins);
        if(newBall != null)
        {
            newBall.GetComponent<Renderer>().material.color = ball.GetComponent<Renderer>().material.color;
        }
        
    }

    public void NextLevel()
    {
        currentStage++;
        UIManager.displayLevel++;
        GameObject[] balls;
        balls = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject b in balls)
        {
            b.GetComponent<BallController>().ResetBall();
        }
        FindObjectOfType<HelixController>().LoadStage(currentStage);
        FindObjectOfType<coinSpawn>().spawnCoins();

        PlayerPrefs.SetInt("lastStage", currentStage);
        Debug.Log("Next level>");
        Destroy(newBall);
        if (currentStage >= 1)
        {
            if(newBall != null)
            {
                Destroy(newBall);
            }
            newBall = Instantiate(ball, new Vector3(1.68f, 3.979f, -0.2f), ball.transform.rotation);
        }

        if(connectedToGooglePlay)
        {
            Social.ReportScore(best, GPGSIds.leaderboard_helix_jump_trick_or_treat, LeaderboardUpdate);
        }
    }

    public void PreviousLevel()
    {
        currentStage--;
        UIManager.displayLevel--;
        GameObject[] balls;
        balls = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject b in balls)
        {
            b.GetComponent<BallController>().ResetBall();
        }
        
        FindObjectOfType<HelixController>().LoadStage(currentStage);
        FindObjectOfType<coinSpawn>().spawnCoins();

        //PlayerPrefs.SetInt("TotalCoins", coins);
        PlayerPrefs.SetInt("lastStage", currentStage);
        Debug.Log("previous level<");
        Destroy(newBall);
        if (currentStage >= 1)
        {
            if (newBall != null)
            {
                Destroy(newBall);
            }
            newBall = Instantiate(ball, new Vector3(1.68f, 3.979f, -0.2f), ball.transform.rotation);
        }
    }

    public void RestartLevel()
    {
        Debug.Log("GameOver");
        //Show ads
        FindObjectOfType<InterstitialAdExample>().ShowAd();
        singleton.score = 0;

        FindObjectOfType<BallController>().ResetBall();
        FindObjectOfType<HelixController>().LoadStage(currentStage);
        Destroy(newBall);
        if (currentStage >= 1)
        {
            if (newBall != null)
            {
                Destroy(newBall);
            }
            newBall = Instantiate(ball, new Vector3(1.68f, 3.979f, -0.2f), ball.transform.rotation);
        }
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
