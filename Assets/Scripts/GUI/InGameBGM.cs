using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class InGameBGM : MonoBehaviour
{
    public AudioMixer audioMixerBGM;
    public GameObject volumeSliderBGM;

    public AudioSource BGM;
    public bool attivato = false;

    void Start()
    {
        BGM = gameObject.GetComponent<AudioSource>();

        float value;
        bool result = audioMixerBGM.GetFloat("volume", out value);
        if (result)
        {
            volumeSliderBGM.GetComponent<Slider>().value = value;
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && attivato == false)
        {
            BGM.Play();
            attivato = true;
        }
        else if (SceneManager.GetActiveScene().buildIndex != 1 && attivato == true)
        {
            BGM.Stop();
            attivato = false;
        }
    }
}
