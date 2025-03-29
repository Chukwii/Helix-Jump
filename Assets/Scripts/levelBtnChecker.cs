using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelBtnChecker : MonoBehaviour
{
    public int num;
    // Update is called once per frame
    void Update()
    {
        if (num < PlayerPrefs.GetInt("lastStage"))
        {
            this.GetComponent<Image>().color = new Color32(6, 158, 103, 255);
            this.transform.parent.GetComponent<Button>().enabled = true;
        }
        else if(num == PlayerPrefs.GetInt("lastStage"))
        {
            this.transform.parent.GetComponent<Button>().enabled = true;
            this.GetComponent<Image>().color = new Color32(255, 130, 0, 255);
        }
    }
}
