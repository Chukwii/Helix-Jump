using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassCheck : MonoBehaviour
{
    public GameObject passSound;
    public AudioSource As;

    void Awake()
    {
        passSound = GameObject.FindGameObjectWithTag("pass");
        As = passSound.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter()
    {
        
        GameManager.singleton.AddScore(7);
        FindObjectOfType<BallController>().perfectPass++;
        Debug.Log("PerfectPass is increased");

        if(FindObjectOfType<ButtonManager>().sfxOn == true)
            As.Play();
    }
}
