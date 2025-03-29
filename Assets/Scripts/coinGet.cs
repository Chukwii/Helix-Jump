using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinGet : MonoBehaviour
{
   void OnTriggerEnter(Collider trig)
    {
        GameManager.singleton.coins += 15;
        this.gameObject.SetActive(false);      
    }
}
