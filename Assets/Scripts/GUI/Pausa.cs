using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Pausa : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PausaUI;
    public GameObject GameOverUI;
    public GameObject FineGiocoUI;

    public AudioMixer audioMixer;
    public GameObject volumeSlider;

    public AudioMixer audioMixerBGM;
    public GameObject volumeSliderBGM;

    void Start()
    {
        float value;
        bool result = audioMixer.GetFloat("volume", out value);
        if (result)
        {
            volumeSlider.GetComponent<Slider>().value = value;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameOverUI.activeSelf==false && FineGiocoUI.activeSelf == false)
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }

        }


    }


    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetVolumeBGM(float volume)
    {
        audioMixerBGM.SetFloat("volume", volume);
    }

    public void Resume()
    {
        PausaUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        PausaUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

     public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

}
