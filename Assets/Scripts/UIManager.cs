using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text textScore;
    [SerializeField] private Text textBest;
    [SerializeField] private Text textCoins;
    [SerializeField] private Text level;
    public static int displayLevel = 1;

    // Update is called once per frame
    void Update()
    {
        textBest.text = "Best: " + GameManager.singleton.best;
        textScore.text = "Score: " + GameManager.singleton.score;
        textCoins.text = " " + GameManager.singleton.coins;
        level.text = " " + displayLevel; 
    }
}
