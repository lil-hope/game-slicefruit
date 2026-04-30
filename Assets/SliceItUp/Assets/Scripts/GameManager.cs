using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //----------------------------------------------
    //Thank you for purchasing the asset! If you have any questions/suggestions, don't hesitate to contact me!
    //E-mail: ragendom@gmail.com
    //Please let me know your impressions about the asset by leaving a review, I will appreciate it.
    //----------------------------------------------

    public GameObject startPanel, endPanel, skinsPanel, pausedPanel, clearedPanel, pauseButton, muteImage, reviveButton, levelBarTransparent;
    public TextMeshProUGUI scoreText, highScoreText, clearedScoreText, clearedHighScoreText, endScoreText, endHighScoreText;

    [HideInInspector]
    public bool gameIsOver = false;

	void Start () {
        //UNCOMMENT THE FOLLOWING LINES IF YOU ENABLED UNITY ADS AT UNITY SERVICES AND REOPENED THE PROJECT!
        //if (FindObjectOfType<AdManager>().unityAds)
        //    CallUnityAds();     //Calls Unity Ads
        //else
        CallAdmobAds();     //Calls Admob Ads

        StartPanelActivation();
        HighScoreCheck();
        AudioCheck();
	}

    //UNCOMMENT THE FOLLOWING LINES IF YOU ENABLED UNITY ADS AT UNITY SERVICES AND REOPENED THE PROJECT!
    //public void CallUnityAds()
    //{
    //    if (Time.time != Time.timeSinceLevelLoad)
    //        FindObjectOfType<AdManager>().ShowUnityVideoAd();      //Shows Interstitial Ad when game starts (except for the first time)
    //    FindObjectOfType<AdManager>().HideAdmobBanner();
    //}

    public void CallAdmobAds()
    {
        FindObjectOfType<AdManager>().ShowAdmobBanner();        //Shows Banner Ad when game starts
        if (Time.time != Time.timeSinceLevelLoad)
            FindObjectOfType<AdManager>().ShowAdmobInterstitial();      //Shows Interstitial Ad when game starts (except for the first time)
    }

    public void Initialize()
    {
        scoreText.enabled = false;
        pauseButton.SetActive(false);
        levelBarTransparent.SetActive(false);
    }

    public void StartPanelActivation()
    {
        Initialize();
        startPanel.SetActive(true);
        endPanel.SetActive(false);
        skinsPanel.SetActive(false);
        pausedPanel.SetActive(false);
        clearedPanel.SetActive(false);
    }

    public void ClearedPanelActivation()
    {
        Initialize();
        startPanel.SetActive(false);
        endPanel.SetActive(false);
        skinsPanel.SetActive(false);
        pausedPanel.SetActive(false);
        clearedPanel.SetActive(true);
        HighScoreCheck();
        levelBarTransparent.SetActive(false);
    }

    public void EndPanelActivation()
    {
        gameIsOver = true;
        FindObjectOfType<KnifeMovement>().enabled = false;
        FindObjectOfType<AudioManager>().DeathSound();
        FindObjectOfType<Knife>().enabled = false;
        startPanel.SetActive(false);
        endPanel.SetActive(true);
        skinsPanel.SetActive(false);
        pausedPanel.SetActive(false);
        scoreText.enabled = false;
        endScoreText.text = scoreText.text;
        pauseButton.SetActive(false);
        clearedPanel.SetActive(false);
        HighScoreCheck();
        levelBarTransparent.SetActive(false);
    }

    public void SkinsPanelActivation()
    {
        startPanel.SetActive(false);
        skinsPanel.SetActive(true);
        pausedPanel.SetActive(false);
        clearedPanel.SetActive(false);
        levelBarTransparent.SetActive(false);
    }

    public void PausedPanelActivation()
    {
        startPanel.SetActive(false);
        endPanel.SetActive(false);
        skinsPanel.SetActive(false);
        pausedPanel.SetActive(true);
        clearedPanel.SetActive(false);
    }

    public void HighScoreCheck()
    {
        if (FindObjectOfType<ScoreManager>().score > PlayerPrefs.GetInt("HighScore", 0))
            PlayerPrefs.SetInt("HighScore", FindObjectOfType<ScoreManager>().score);
        
        clearedHighScoreText.text = endHighScoreText.text = highScoreText.text = "BEST " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        clearedScoreText.text = FindObjectOfType<ScoreManager>().score.ToString();
    }

    public void AudioCheck()
    {
        if (PlayerPrefs.GetInt("Audio", 0) == 0)
        {
            muteImage.SetActive(false);
            FindObjectOfType<AudioManager>().soundIsOn = true;
            FindObjectOfType<AudioManager>().PlayBackgroundMusic();
        }
        else
        {
            muteImage.SetActive(true);
            FindObjectOfType<AudioManager>().soundIsOn = false;
            FindObjectOfType<AudioManager>().StopBackgroundMusic();
        }
    }

    public void StartButton()
    {
        pauseButton.SetActive(true);
        scoreText.enabled = true;
        startPanel.SetActive(false);
        FindObjectOfType<AudioManager>().ButtonClickSound();
        FindObjectOfType<Knife>().enabled = true;
        levelBarTransparent.SetActive(true);
    }

    public void RestartButton()
    {
        FindObjectOfType<AudioManager>().ButtonClickSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SkinsBackButton()
    {
        StartPanelActivation();
        FindObjectOfType<AudioManager>().ButtonClickSound();
    }

    public void AudioButton()
    {
        FindObjectOfType<AudioManager>().ButtonClickSound();
        if (PlayerPrefs.GetInt("Audio", 0) == 0)
            PlayerPrefs.SetInt("Audio", 1);
        else
            PlayerPrefs.SetInt("Audio", 0);
        AudioCheck();
    }

    public void SkinsButton()
    {
        SkinsPanelActivation();
        FindObjectOfType<AudioManager>().ButtonClickSound();
    }

    public void PauseButton()
    {
        pauseButton.SetActive(false);
        PausedPanelActivation();
        scoreText.enabled = false;
        FindObjectOfType<AudioManager>().StopBackgroundMusic();
        Time.timeScale = 0f;
    }

    public void ResumeButton()
    {
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().PlayBackgroundMusic();
        scoreText.enabled = true;
        pauseButton.SetActive(true);
        pausedPanel.SetActive(false);
    }

    public void HomeButton()
    {
        ResumeButton();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Revive()
    {
        //UNCOMMENT THE FOLLOWING LINES IF YOU ENABLED UNITY ADS AT UNITY SERVICES AND REOPENED THE PROJECT!
        //if (FindObjectOfType<AdManager>().unityAds)
        //    FindObjectOfType<AdManager>().ShowUnityRewardVideoAd();       //Shows Unity Reward Video ad
        //else
        FindObjectOfType<AdManager>().ShowAdmobRewardVideo();       //Shows Admob Reward Video ad

        endPanel.SetActive(false);
        reviveButton.SetActive(false);
        pauseButton.SetActive(true);
        scoreText.enabled = true;
        levelBarTransparent.SetActive(true);

        FindObjectOfType<Knife>().enabled = true;
        FindObjectOfType<KnifeMovement>().enabled = true;

        gameIsOver = false;
    }
}
