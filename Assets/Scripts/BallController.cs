using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private bool ignoreNextCollision;
    public Rigidbody rb;
    public float impulseForce = 5f;
    private Vector3 startPos;
    public float perfectPass = 0;
    public bool isSuperSpeedActive;
    public GameObject splashParticle;
    public AudioSource bouseSound;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ignoreNextCollision)
            return;
        // Debug.Log("is boucing");


        if (isSuperSpeedActive)
        {
            if (!collision.transform.GetComponent<Goal>())
            {
                Destroy(collision.transform.parent.gameObject, 0.3f);
                Debug.Log("destroying platform");
            }
        }
        else
        {
            //Adding reset functionality via DeathPart - initialised when DeathPart is hit
            DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
            if (deathPart && this.gameObject.name == "Ball")
            {
                deathPart.HitDeathPart();
                GameManager.singleton.RestartLevel();
                ResetBall();
            }
            else if(deathPart && this.gameObject.name == "Ball(Clone)")
            {
                Destroy(this.gameObject);
                GameObject realBall = GameObject.Find("Ball");
                realBall.GetComponent<BallController>().ResetBall();
                GameManager.singleton.RestartLevel();
            }
                
        }

        GameObject Splash = Instantiate(splashParticle, transform.position, transform.rotation);
        Splash.transform.parent = collision.gameObject.transform;

        if(FindObjectOfType<ButtonManager>().sfxOn == true)
        {
            bouseSound.Play();
        }
        
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * impulseForce, ForceMode.Impulse);

        ignoreNextCollision = true;
        Invoke("AllowCollision", .2f);

        perfectPass = 0;
        isSuperSpeedActive = false;
    }

    private void Update()
    {
        splashParticle.GetComponent<Renderer>().sharedMaterial.color = this.gameObject.GetComponent<Renderer>().material.color;
        if (perfectPass >= 3 && !isSuperSpeedActive)
        {
            isSuperSpeedActive = true;
            rb.AddForce(Vector3.down * 10, ForceMode.Impulse);
            GameManager.singleton.AddScore(17);
        }
    }

    private void AllowCollision()
    {
        ignoreNextCollision = false;
    }
    
    public void ResetBall()
    {
        transform.position = startPos;
    }
}
