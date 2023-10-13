using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject characterPanelObj;
    public GameObject shopPanelObj;
    public GameObject startPanel;
    public GameObject settingsPanel;
    public GameObject pauseTxt;
    public GameObject endGamePanelObj;

    public AudioSource music;
    public GameObject musicObj;
    public bool musicOn = true;
    public GameObject sfxObj;
    public bool sfxOn = true;

    //magicianHat
    public GameObject magicianHat;
    public bool hasMagicianHat = false;
    public GameObject magicianHatPrice;
    public GameObject magicianHatCheck;

    //CowboyHat
    public GameObject cowboyHat;
    public bool hasCowboyHat = false;
    public GameObject cowboyHatPrice;
    public GameObject cowboyHatCheck;

    //Crown
    public GameObject crown;
    public bool hasCrown = false;
    public GameObject crownPrice;
    public GameObject crownCheck;

    //MinerHat
    public GameObject minerHat;
    public bool hasMinerHat = false;
    public GameObject minerHatPrice;
    public GameObject minerHatCheck;

    //PajamaHat
    public GameObject pajamaHat;
    public bool hasPajamaHat = false;
    public GameObject pajamaHatPrice;
    public GameObject pajamaHatCheck;

    //PoliceCap
    public GameObject policeCap;
    public bool hasPoliceCap = false;
    public GameObject policeCapPrice;
    public GameObject policeCapCheck;

    //ShowerCap
    public GameObject showerCap;
    public bool hasShowerCap = false;
    public GameObject showerCapPrice;
    public GameObject showerCapCheck;

    //Sombrero
    public GameObject sombrero;
    public bool hasSombrero = false;
    public GameObject sombreroPrice;
    public GameObject sombreroCheck;

    //VikingHelmet
    public GameObject vikingHelmet;
    public bool hasVikingHelmet = false;
    public GameObject vikingHelmetPrice;
    public GameObject vikingHelmetCheck;


    public int magicianHatOn = 0;
    public int cowboyHatOn = 0;
    public int crownOn = 0;
    public int minerHatOn = 0;
    public int pajamasHatOn = 0;
    public int policeCapOn = 0;
    public int ShoweCapOn = 0;
    public int SombreroOn = 0;
    public int vikigHatOn = 0;

    void Awake()
    {
        magicianHatOn = PlayerPrefs.GetInt("magicianHatOn");
        cowboyHatOn = PlayerPrefs.GetInt("cowboyHatOn");
        crownOn = PlayerPrefs.GetInt("crownOn");
        minerHatOn = PlayerPrefs.GetInt("minerHatOn");
        pajamasHatOn = PlayerPrefs.GetInt("pajamasHatOn");
        policeCapOn = PlayerPrefs.GetInt("policeCapOn");
        ShoweCapOn = PlayerPrefs.GetInt("ShoweCapOn");
        SombreroOn = PlayerPrefs.GetInt("SombreroOn");
        vikigHatOn = PlayerPrefs.GetInt("vikigHatOn");
    }

    void Update()
    {
        PlayerPrefs.SetInt("magicianHatOn", magicianHatOn);
        PlayerPrefs.SetInt("cowboyHatOn", cowboyHatOn);
        PlayerPrefs.SetInt("crownOn", crownOn);
        PlayerPrefs.SetInt("minerHatOn", minerHatOn);
        PlayerPrefs.SetInt("pajamasHatOn", pajamasHatOn);
        PlayerPrefs.SetInt("policeCapOn", policeCapOn);
        PlayerPrefs.SetInt("ShoweCapOn", ShoweCapOn);
        PlayerPrefs.SetInt("SombreroOn", SombreroOn);
        PlayerPrefs.SetInt("vikigHatOn", vikigHatOn);
        boughtHats();
    }

    public void boughtHats()
    {
        if(magicianHatOn == 1)
        {
            hasMagicianHat = true;
            magicianHatPrice.SetActive(false);
        }

        if(cowboyHatOn == 1)
        {
            hasCowboyHat = true;
            cowboyHatPrice.SetActive(false);
        }
        
        if(crownOn == 1)
        {
            hasCrown = true;
            crownPrice.SetActive(false);
        }

        if(minerHatOn == 1)
        {
            hasMinerHat = true;
            minerHatPrice.SetActive(false);
        }

        if(pajamasHatOn == 1)
        {
            hasPajamaHat = true;
            pajamaHatPrice.SetActive(false);
        }

        if (policeCapOn == 1)
        {
            hasPoliceCap = true;
            policeCapPrice.SetActive(false);
        }

        if(ShoweCapOn == 1)
        {
            hasShowerCap = true;
            showerCapPrice.SetActive(false);
        }

        if(SombreroOn == 1)
        {
            hasSombrero = true;
            sombreroPrice.SetActive(false);
        }

        if(vikigHatOn == 1)
        {
            hasVikingHelmet = true;
            vikingHelmetPrice.SetActive(false);
        }
    }

    public void buyMagicianHat()
    {
        if (GameManager.singleton.coins >= 50 && hasMagicianHat == false)
        {
            hasMagicianHat = true;
            magicianHatPrice.SetActive(false);
            GameManager.singleton.coins -= 50;
            magicianHat.SetActive(true);
            cowboyHat.SetActive(false);
            crown.SetActive(false);
            minerHat.SetActive(false);
            pajamaHat.SetActive(false);
            policeCap.SetActive(false);
            showerCap.SetActive(false);
            sombrero.SetActive(false);
            vikingHelmet.SetActive(false);

            magicianHatCheck.SetActive(true);
            crownCheck.SetActive(false);
            cowboyHatCheck.SetActive(false);
            minerHatCheck.SetActive(false);
            pajamaHatCheck.SetActive(false);
            policeCapCheck.SetActive(false);
            showerCapCheck.SetActive(false);
            sombreroCheck.SetActive(false);
            vikingHelmetCheck.SetActive(false);

            magicianHatOn = 1;
        }

        else if(hasMagicianHat == true)
        {
            magicianHat.SetActive(true);
            cowboyHat.SetActive(false);
            crown.SetActive(false);
            minerHat.SetActive(false);
            pajamaHat.SetActive(false);
            policeCap.SetActive(false);
            showerCap.SetActive(false);
            sombrero.SetActive(false);
            vikingHelmet.SetActive(false);

            magicianHatCheck.SetActive(true);
            crownCheck.SetActive(false);
            cowboyHatCheck.SetActive(false);
            minerHatCheck.SetActive(false);
            pajamaHatCheck.SetActive(false);
            policeCapCheck.SetActive(false);
            showerCapCheck.SetActive(false);
            sombreroCheck.SetActive(false);
            vikingHelmetCheck.SetActive(false);
        }
    }
    public void buyCowboyHat()
    {
        if (GameManager.singleton.coins >= 100 && hasCowboyHat == false)
        {
            hasCowboyHat = true;
            cowboyHatPrice.SetActive(false);
            GameManager.singleton.coins -= 100;
            cowboyHat.SetActive(true);
            magicianHat.SetActive(false);
            crown.SetActive(false);
            minerHat.SetActive(false);
            pajamaHat.SetActive(false);
            policeCap.SetActive(false);
            showerCap.SetActive(false);
            sombrero.SetActive(false);
            vikingHelmet.SetActive(false);

            magicianHatCheck.SetActive(false);
            crownCheck.SetActive(false);
            cowboyHatCheck.SetActive(true);
            minerHatCheck.SetActive(false);
            pajamaHatCheck.SetActive(false);
            policeCapCheck.SetActive(false);
            showerCapCheck.SetActive(false);
            sombreroCheck.SetActive(false);
            vikingHelmetCheck.SetActive(false);

            cowboyHatOn = 1;
        }
        else if (hasCowboyHat == true)
        {
            cowboyHat.SetActive(true);
            magicianHat.SetActive(false);
            crown.SetActive(false);
            minerHat.SetActive(false);
            pajamaHat.SetActive(false);
            policeCap.SetActive(false);
            showerCap.SetActive(false);
            sombrero.SetActive(false);
            vikingHelmet.SetActive(false);

            magicianHatCheck.SetActive(false);
            crownCheck.SetActive(false);
            cowboyHatCheck.SetActive(true);
            minerHatCheck.SetActive(false);
            pajamaHatCheck.SetActive(false);
            policeCapCheck.SetActive(false);
            showerCapCheck.SetActive(false);
            sombreroCheck.SetActive(false);
            vikingHelmetCheck.SetActive(false);
        }
    }
    
    public void buyCrown()
    {
        if (GameManager.singleton.coins >= 150 && hasCrown == false)
        {
            hasCrown = true;
            crownPrice.SetActive(false);
            GameManager.singleton.coins -= 150;
            crown.SetActive(true);
            magicianHat.SetActive(false);
            cowboyHat.SetActive(false);
            minerHat.SetActive(false);
            pajamaHat.SetActive(false);
            policeCap.SetActive(false);
            showerCap.SetActive(false);
            sombrero.SetActive(false);
            vikingHelmet.SetActive(false);

            magicianHatCheck.SetActive(false);
            crownCheck.SetActive(true);
            cowboyHatCheck.SetActive(false);
            minerHatCheck.SetActive(false);
            pajamaHatCheck.SetActive(false);
            policeCapCheck.SetActive(false);
            showerCapCheck.SetActive(false);
            sombreroCheck.SetActive(false);
            vikingHelmetCheck.SetActive(false);

            crownOn = 1;
        }
        else if (hasCrown == true)
        {
            crown.SetActive(true);
            magicianHat.SetActive(false);
            cowboyHat.SetActive(false);
            minerHat.SetActive(false);
            pajamaHat.SetActive(false);
            policeCap.SetActive(false);
            showerCap.SetActive(false);
            sombrero.SetActive(false);
            vikingHelmet.SetActive(false);

            magicianHatCheck.SetActive(false);
            crownCheck.SetActive(true);
            cowboyHatCheck.SetActive(false);
            minerHatCheck.SetActive(false);
            pajamaHatCheck.SetActive(false);
            policeCapCheck.SetActive(false);
            showerCapCheck.SetActive(false);
            sombreroCheck.SetActive(false);
            vikingHelmetCheck.SetActive(false);
        }
    }
    
    public void buyMinerHat()
    {
        if (GameManager.singleton.coins >= 200 && hasMinerHat == false)
        {
            hasMinerHat = true;
            minerHatPrice.SetActive(false);
            GameManager.singleton.coins -= 200;
            minerHat.SetActive(true);
            crown.SetActive(false);
            magicianHat.SetActive(false);
            cowboyHat.SetActive(false);
            pajamaHat.SetActive(false);
            policeCap.SetActive(false);
            showerCap.SetActive(false);
            sombrero.SetActive(false);
            vikingHelmet.SetActive(false);

            magicianHatCheck.SetActive(false);
            crownCheck.SetActive(false);
            cowboyHatCheck.SetActive(false);
            minerHatCheck.SetActive(true);
            pajamaHatCheck.SetActive(false);
            policeCapCheck.SetActive(false);
            showerCapCheck.SetActive(false);
            sombreroCheck.SetActive(false);
            vikingHelmetCheck.SetActive(false);

            minerHatOn = 1;
        }
        else if (hasMinerHat == true)
        {
            minerHat.SetActive(true);
            crown.SetActive(false);
            magicianHat.SetActive(false);
            cowboyHat.SetActive(false);
            pajamaHat.SetActive(false);
            policeCap.SetActive(false);
            showerCap.SetActive(false);
            sombrero.SetActive(false);
            vikingHelmet.SetActive(false);

            magicianHatCheck.SetActive(false);
            crownCheck.SetActive(false);
            cowboyHatCheck.SetActive(false);
            minerHatCheck.SetActive(true);
            pajamaHatCheck.SetActive(false);
            policeCapCheck.SetActive(false);
            showerCapCheck.SetActive(false);
            sombreroCheck.SetActive(false);
            vikingHelmetCheck.SetActive(false);
        }
    }
    
    public void buyPajamaHat()
    {
        if (GameManager.singleton.coins >= 250 && hasPajamaHat == false)
        {
            hasPajamaHat = true;
            pajamaHatPrice.SetActive(false);
            GameManager.singleton.coins -= 250;
            pajamaHat.SetActive(true);
            minerHat.SetActive(false);
            crown.SetActive(false);
            magicianHat.SetActive(false);
            cowboyHat.SetActive(false);
            policeCap.SetActive(false);
            showerCap.SetActive(false);
            sombrero.SetActive(false);
            vikingHelmet.SetActive(false);

            magicianHatCheck.SetActive(false);
            crownCheck.SetActive(false);
            cowboyHatCheck.SetActive(false);
            minerHatCheck.SetActive(false);
            pajamaHatCheck.SetActive(true);
            policeCapCheck.SetActive(false);
            showerCapCheck.SetActive(false);
            sombreroCheck.SetActive(false);
            vikingHelmetCheck.SetActive(false);

            pajamasHatOn = 1;
        }
        else if (hasPajamaHat == true)
        {
            pajamaHat.SetActive(true);
            minerHat.SetActive(false);
            crown.SetActive(false);
            magicianHat.SetActive(false);
            cowboyHat.SetActive(false);
            policeCap.SetActive(false);
            showerCap.SetActive(false);
            sombrero.SetActive(false);
            vikingHelmet.SetActive(false);

            magicianHatCheck.SetActive(false);
            crownCheck.SetActive(false);
            cowboyHatCheck.SetActive(false);
            minerHatCheck.SetActive(false);
            pajamaHatCheck.SetActive(true);
            policeCapCheck.SetActive(false);
            showerCapCheck.SetActive(false);
            sombreroCheck.SetActive(false);
            vikingHelmetCheck.SetActive(false);
        }
    }
    
    public void buyPoliceCap()
    {
        if (GameManager.singleton.coins >= 300 && hasPoliceCap == false)
        {
            hasPoliceCap = true;
            policeCapPrice.SetActive(false);
            GameManager.singleton.coins -= 300;
            policeCap.SetActive(true);
            pajamaHat.SetActive(false);
            minerHat.SetActive(false);
            crown.SetActive(false);
            magicianHat.SetActive(false);
            cowboyHat.SetActive(false);
            showerCap.SetActive(false);
            sombrero.SetActive(false);
            vikingHelmet.SetActive(false);

            magicianHatCheck.SetActive(false);
            crownCheck.SetActive(false);
            cowboyHatCheck.SetActive(false);
            minerHatCheck.SetActive(false);
            pajamaHatCheck.SetActive(false);
            policeCapCheck.SetActive(true);
            showerCapCheck.SetActive(false);
            sombreroCheck.SetActive(false);
            vikingHelmetCheck.SetActive(false);

            policeCapOn = 1;
        }
        else if (hasPoliceCap == true)
        {
            policeCap.SetActive(true);
            pajamaHat.SetActive(false);
            minerHat.SetActive(false);
            crown.SetActive(false);
            magicianHat.SetActive(false);
            cowboyHat.SetActive(false);
            showerCap.SetActive(false);
            sombrero.SetActive(false);
            vikingHelmet.SetActive(false);

            magicianHatCheck.SetActive(false);
            crownCheck.SetActive(false);
            cowboyHatCheck.SetActive(false);
            minerHatCheck.SetActive(false);
            pajamaHatCheck.SetActive(false);
            policeCapCheck.SetActive(true);
            showerCapCheck.SetActive(false);
            sombreroCheck.SetActive(false);
            vikingHelmetCheck.SetActive(false);
        }
    }
    
    public void buyShowerCap()
    {
        if (GameManager.singleton.coins >= 350 && hasShowerCap == false)
        {
            hasShowerCap = true;
            showerCapPrice.SetActive(false);
            GameManager.singleton.coins -= 350;
            showerCap.SetActive(true);
            policeCap.SetActive(false);
            pajamaHat.SetActive(false);
            minerHat.SetActive(false);
            crown.SetActive(false);
            magicianHat.SetActive(false);
            cowboyHat.SetActive(false);
            sombrero.SetActive(false);
            vikingHelmet.SetActive(false);

            magicianHatCheck.SetActive(false);
            crownCheck.SetActive(false);
            cowboyHatCheck.SetActive(false);
            minerHatCheck.SetActive(false);
            pajamaHatCheck.SetActive(false);
            policeCapCheck.SetActive(false);
            showerCapCheck.SetActive(true);
            sombreroCheck.SetActive(false);
            vikingHelmetCheck.SetActive(false);

            ShoweCapOn = 1;
        }
        else if (hasShowerCap == true)
        {
            showerCap.SetActive(true);
            policeCap.SetActive(false);
            pajamaHat.SetActive(false);
            minerHat.SetActive(false);
            crown.SetActive(false);
            magicianHat.SetActive(false);
            cowboyHat.SetActive(false);
            sombrero.SetActive(false);
            vikingHelmet.SetActive(false);

            magicianHatCheck.SetActive(false);
            crownCheck.SetActive(false);
            cowboyHatCheck.SetActive(false);
            minerHatCheck.SetActive(false);
            pajamaHatCheck.SetActive(false);
            policeCapCheck.SetActive(false);
            showerCapCheck.SetActive(true);
            sombreroCheck.SetActive(false);
            vikingHelmetCheck.SetActive(false);
        }
    }
    
    public void buySombrero()
    {
        if (GameManager.singleton.coins >= 400 && hasSombrero == false)
        {
            hasSombrero = true;
            sombreroPrice.SetActive(false);
            GameManager.singleton.coins -= 400;
            sombrero.SetActive(true);
            showerCap.SetActive(false);
            policeCap.SetActive(false);
            pajamaHat.SetActive(false);
            minerHat.SetActive(false);
            crown.SetActive(false);
            magicianHat.SetActive(false);
            cowboyHat.SetActive(false);
            vikingHelmet.SetActive(false);

            magicianHatCheck.SetActive(false);
            crownCheck.SetActive(false);
            cowboyHatCheck.SetActive(false);
            minerHatCheck.SetActive(false);
            pajamaHatCheck.SetActive(false);
            policeCapCheck.SetActive(false);
            showerCapCheck.SetActive(false);
            sombreroCheck.SetActive(true);
            vikingHelmetCheck.SetActive(false);

            SombreroOn = 1;
        }
        else if (hasSombrero == true)
        {
            sombrero.SetActive(true);
            showerCap.SetActive(false);
            policeCap.SetActive(false);
            pajamaHat.SetActive(false);
            minerHat.SetActive(false);
            crown.SetActive(false);
            magicianHat.SetActive(false);
            cowboyHat.SetActive(false);
            vikingHelmet.SetActive(false);

            magicianHatCheck.SetActive(false);
            crownCheck.SetActive(false);
            cowboyHatCheck.SetActive(false);
            minerHatCheck.SetActive(false);
            pajamaHatCheck.SetActive(false);
            policeCapCheck.SetActive(false);
            showerCapCheck.SetActive(false);
            sombreroCheck.SetActive(true);
            vikingHelmetCheck.SetActive(false);
        }
    }
    
    public void buyVikingHelmet()
    {
        if (GameManager.singleton.coins >= 500 && hasVikingHelmet == false)
        {
            hasVikingHelmet = true;
            vikingHelmetPrice.SetActive(false);
            GameManager.singleton.coins -= 500;
            vikingHelmet.SetActive(true);
            sombrero.SetActive(false);
            showerCap.SetActive(false);
            policeCap.SetActive(false);
            pajamaHat.SetActive(false);
            minerHat.SetActive(false);
            crown.SetActive(false);
            magicianHat.SetActive(false);
            cowboyHat.SetActive(false);

            magicianHatCheck.SetActive(false);
            crownCheck.SetActive(false);
            cowboyHatCheck.SetActive(false);
            minerHatCheck.SetActive(false);
            pajamaHatCheck.SetActive(false);
            policeCapCheck.SetActive(false);
            showerCapCheck.SetActive(false);
            sombreroCheck.SetActive(false);
            vikingHelmetCheck.SetActive(true);

            vikigHatOn = 1;
        }
        else if (hasVikingHelmet == true)
        {
            vikingHelmet.SetActive(true);
            sombrero.SetActive(false);
            showerCap.SetActive(false);
            policeCap.SetActive(false);
            pajamaHat.SetActive(false);
            minerHat.SetActive(false);
            crown.SetActive(false);
            magicianHat.SetActive(false);
            cowboyHat.SetActive(false);

            magicianHatCheck.SetActive(false);
            crownCheck.SetActive(false);
            cowboyHatCheck.SetActive(false);
            minerHatCheck.SetActive(false);
            pajamaHatCheck.SetActive(false);
            policeCapCheck.SetActive(false);
            showerCapCheck.SetActive(false);
            sombreroCheck.SetActive(false);
            vikingHelmetCheck.SetActive(true);
        }
    }

    //show and close character panel
    public void characterPanel()
    {
        characterPanelObj.SetActive(true);
    }

    public void cancelCharacterPanel()
    {
        characterPanelObj.SetActive(false);
    }

    //shop panel
    public void shopPanel()
    {
        shopPanelObj.SetActive(true);
    }

    public void cancelShopPanel()
    {
        shopPanelObj.SetActive(false);
    }

    //settings panel
    public void settingsPanelfunc()
    {
        settingsPanel.SetActive(true);
        startPanel.SetActive(false);
    }

    public void cancelsettingsPanelfunc()
    {
        settingsPanel.SetActive(false);
        startPanel.SetActive(true);
    }

    public void pauseGame()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseTxt.SetActive(true);
        }
        else if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseTxt.SetActive(false);
        }
    }

    public void nextLevel()
    {
        Time.timeScale = 1;
        GameManager.singleton.NextLevel();
        startPanel.SetActive(true);
        endGamePanelObj.SetActive(false);
    }

    public void previousLevel()
    {
        if (GameManager.singleton.currentStage >= 1)
        {
            Time.timeScale = 1;
            GameManager.singleton.PreviousLevel();
            startPanel.SetActive(true);
            endGamePanelObj.SetActive(false);
        }
        
    }

    public void startGame()
    {
        startPanel.SetActive(false);
        if(musicOn == true)
        {
            music.Play();
        }
        
    }

    public void muteMusic()
    {
        if(musicOn == true)
        {
            musicObj.SetActive(false);
            musicOn = false;
        }
        else if(musicOn == false)
        {
            musicObj.SetActive(true);
            musicOn = true;
        }
    }
    
    public void muteSfx()
    {
        if(sfxOn == true)
        {
            sfxObj.SetActive(false);
            sfxOn = false;
        }
        else if(sfxOn == false)
        {
            sfxObj.SetActive(true);
            sfxOn = true;
        }
    }
}
