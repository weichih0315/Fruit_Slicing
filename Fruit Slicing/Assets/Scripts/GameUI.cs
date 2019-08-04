using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour {

    public Text scoreUI;
    public Text gameoverScoreUI;

    public GameObject[] hp_UI;
    public GameObject[] hpX_UI;

    public GameObject gameStartUIHolder;
    public GameObject gameOverUIHolder;

    public GameObject pauseMenuHolder;
    public GameObject mainMenuHolder;
    public GameObject optionsMenuHolder;

    public Slider[] volumeSliders;

    void Start()
    {
        volumeSliders[0].value = AudioManager.instance.masterVolumePercent;
        volumeSliders[1].value = AudioManager.instance.musicVolumePercent;
        volumeSliders[2].value = AudioManager.instance.sfxVolumePercent;

        Fruit.OnSliced += FruitOnSliced;
        Boom.OnSliced += BoomOnSliced;
    }

    private void OnDisable()
    {
        Fruit.OnSliced -= FruitOnSliced;
        Boom.OnSliced -= BoomOnSliced;
    }

    private void FruitOnSliced()
    {
        scoreUI.text = "Score : " + ScoreKeeper.score.ToString("D6");
    }

    private void BoomOnSliced()
    {
        int hp = HpKeeper.hp;

        if (hp > 0)
        {
            for (int i = 0; i < hp_UI.Length; i++)
            {
                if (i < hp)
                {
                    hp_UI[i].SetActive(true);
                    hpX_UI[i].SetActive(false);
                }
                else
                {
                    hp_UI[i].SetActive(false);
                    hpX_UI[i].SetActive(true);
                }
            }
        }
        else
        {
            GameOver();
        }
    }



    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseMenuHolder.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenuHolder.SetActive(false);
        }
    }

    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OptionsMenu()
    {
        mainMenuHolder.SetActive(false);
        optionsMenuHolder.SetActive(true);
    }

    public void MainMenu()
    {
        mainMenuHolder.SetActive(true);
        optionsMenuHolder.SetActive(false);
    }

    public void SetMasterVolume(float value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Master);
    }

    public void SetMusicVolume(float value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Music);
    }

    public void SetSfxVolume(float value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Sfx);
    }

    private void GameOver()
    {
        gameStartUIHolder.SetActive(false);
        gameOverUIHolder.SetActive(true);
        gameoverScoreUI.text = "Score : " + ScoreKeeper.score.ToString("D6");
    }
}
