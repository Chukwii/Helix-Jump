using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSpawn : MonoBehaviour
{
    public GameObject[] coins;

    
    public void spawnCoins()
    {
        foreach(GameObject c in coins)
        {
            c.SetActive(true);
        }
    }
}
