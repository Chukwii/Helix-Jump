using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinGet : MonoBehaviour
{
   void OnTriggerEnter(Collider trig)
    {
        GameManager.singleton.coins += 6;
        this.gameObject.SetActive(false);      
    }
}
