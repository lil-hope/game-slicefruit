using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkinManager : MonoBehaviour {

    public GameObject[] lockedSkinImages;
    public int[] requiredTokensToUnlock;
    public TextMeshProUGUI[] requiredTokenTexts;
    public GameObject notEnoughTokensText;

    void Start () {
        PlayerPrefs.SetInt("Skin1Unlocked", 1);     //The first skin is unlocked
        SkinCheck();
        InitializeRequiredTokensTexts();
    }

    public void InitializeRequiredTokensTexts()
    {
        for (int i = 0; i < requiredTokenTexts.Length; i++)     //Loops through the requiedTokenTexts list and sets the texts identical to the requied count of tokens
            requiredTokenTexts[i].text = requiredTokensToUnlock[i].ToString();
    }

    public void SkinCheck()
    {
        for (int i = 0; i < lockedSkinImages.Length; i++)       //Loops through the lockedSkinImages list
        {
            if (PlayerPrefs.GetInt("Skin" + (i + 1).ToString() + "Unlocked", 0) == 1)     //Checks if the list's element is unlocked yet
                lockedSkinImages[i].SetActive(false);       //If it is unlocked, then the lockedImage is disabled
        }
        FindObjectOfType<Spawner>().SkinCheck();
        FindObjectOfType<Knife>().KnifeCheck();
    }

    public void Skin1()
    {
        if (PlayerPrefs.GetInt("Skin", 0) != 0)
        {
            if (PlayerPrefs.GetInt("Skin1Unlocked", 0) == 0)        //If the skin is not unlocked yet
            {
                if (PlayerPrefs.GetInt("Token", 0) < requiredTokensToUnlock[0])       //If the skin cannot be unlocked
                {
                    notEnoughTokensText.GetComponent<Animation>().Play();       //Plays the animation of notEnoughTokensText
                    FindObjectOfType<AudioManager>().NotEnoughTokenSound();     //Plays notEnoughTokenSound
                }
                else    //If the skin can be unlocked
                {
                    PlayerPrefs.SetInt("Skin1Unlocked", 1);     //Unlocks skin
                    FindObjectOfType<ScoreManager>().DecrementToken(requiredTokensToUnlock[0]);     //Decrements the count of tokens by requiredTokensToUnlock's value
                    PlayerPrefs.SetInt("Skin", 0);
                    SkinCheck();        //Enables the selected skin
                    FindObjectOfType<AudioManager>().SkinSwitchSound();     //Plays skinSwitchSound
                }
            }
            else    //If the skin is unlocked
            {
                PlayerPrefs.SetInt("Skin", 0);
                SkinCheck();        //Enables the selected skin
                FindObjectOfType<AudioManager>().SkinSwitchSound();     //Plays skinSwitchSound
            }
        }
    }

    public void Skin2()
    {
        if (PlayerPrefs.GetInt("Skin", 0) != 1)
        {
            if (PlayerPrefs.GetInt("Skin2Unlocked", 0) == 0)        //If the skin is not unlocked yet
            {
                if (PlayerPrefs.GetInt("Token", 0) < requiredTokensToUnlock[1])       //If the skin cannot be unlocked
                {
                    notEnoughTokensText.GetComponent<Animation>().Play();       //Plays the animation of notEnoughTokensText
                    FindObjectOfType<AudioManager>().NotEnoughTokenSound();     //Plays notEnoughTokenSound
                }
                else    //If the skin can be unlocked
                {
                    PlayerPrefs.SetInt("Skin2Unlocked", 1);     //Unlocks skin
                    FindObjectOfType<ScoreManager>().DecrementToken(requiredTokensToUnlock[1]);     //Decrements the count of tokens by requiredTokensToUnlock's value
                    PlayerPrefs.SetInt("Skin", 1);
                    SkinCheck();        //Enables the selected skin
                    FindObjectOfType<AudioManager>().SkinSwitchSound();     //Plays skinSwitchSound
                }
            }
            else    //If the skin is unlocked
            {
                PlayerPrefs.SetInt("Skin", 1);
                SkinCheck();        //Enables the selected skin
                FindObjectOfType<AudioManager>().SkinSwitchSound();     //Plays skinSwitchSound
            }
        }
    }

    public void Skin3()
    {
        if (PlayerPrefs.GetInt("Skin", 0) != 2)
        {
            if (PlayerPrefs.GetInt("Skin3Unlocked", 0) == 0)        //If the skin is not unlocked yet
            {
                if (PlayerPrefs.GetInt("Token", 0) < requiredTokensToUnlock[2])       //If the skin cannot be unlocked
                {
                    notEnoughTokensText.GetComponent<Animation>().Play();       //Plays the animation of notEnoughTokensText
                    FindObjectOfType<AudioManager>().NotEnoughTokenSound();     //Plays notEnoughTokenSound
                }
                else    //If the skin can be unlocked
                {
                    PlayerPrefs.SetInt("Skin3Unlocked", 1);     //Unlocks skin
                    FindObjectOfType<ScoreManager>().DecrementToken(requiredTokensToUnlock[2]);     //Decrements the count of tokens by requiredTokensToUnlock's value
                    PlayerPrefs.SetInt("Skin", 2);
                    SkinCheck();        //Enables the selected skin
                    FindObjectOfType<AudioManager>().SkinSwitchSound();     //Plays skinSwitchSound
                }
            }
            else    //If the skin is unlocked
            {
                PlayerPrefs.SetInt("Skin", 2);
                SkinCheck();        //Enables the selected skin
                FindObjectOfType<AudioManager>().SkinSwitchSound();     //Plays skinSwitchSound
            }
        }
    }

    public void Skin4()
    {
        if (PlayerPrefs.GetInt("Skin", 0) != 3)
        {
            if (PlayerPrefs.GetInt("Skin4Unlocked", 0) == 0)        //If the skin is not unlocked yet
            {
                if (PlayerPrefs.GetInt("Token", 0) < requiredTokensToUnlock[3])       //If the skin cannot be unlocked
                {
                    notEnoughTokensText.GetComponent<Animation>().Play();       //Plays the animation of notEnoughTokensText
                    FindObjectOfType<AudioManager>().NotEnoughTokenSound();     //Plays notEnoughTokenSound
                }
                else    //If the skin can be unlocked
                {
                    PlayerPrefs.SetInt("Skin4Unlocked", 1);     //Unlocks skin
                    FindObjectOfType<ScoreManager>().DecrementToken(requiredTokensToUnlock[3]);     //Decrements the count of tokens by requiredTokensToUnlock's value
                    PlayerPrefs.SetInt("Skin", 3);
                    SkinCheck();        //Enables the selected skin
                    FindObjectOfType<AudioManager>().SkinSwitchSound();     //Plays skinSwitchSound
                }
            }
            else    //If the skin is unlocked
            {
                PlayerPrefs.SetInt("Skin", 3);
                SkinCheck();        //Enables the selected skin
                FindObjectOfType<AudioManager>().SkinSwitchSound();     //Plays skinSwitchSound
            }
        }
    }
}
