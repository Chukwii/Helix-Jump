using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject endGamePanelObj;
    public AudioSource music;

    private void OnCollisionEnter(Collision col)
    {
        music.Stop();
        endGamePanelObj.SetActive(true);
        Time.timeScale = 0;
    }
    
}
