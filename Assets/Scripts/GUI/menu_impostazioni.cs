using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class menu_impostazioni : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject volumeSlider;

    public AudioMixer audioMixerBGM;
    public GameObject volumeSliderBGM;

    public AudioSource BGM;
    public bool attivato=false;

    void Start()
    {
        float value;
        bool result = audioMixer.GetFloat("volume", out value);
        if (result)
        {
            volumeSlider.GetComponent<Slider>().value = value;
        }

        float value2;
        bool result2 = audioMixerBGM.GetFloat("volume", out value2);
        if (result)
        {
            volumeSliderBGM.GetComponent<Slider>().value = value2;
        }
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex==0 && attivato==false)
        {
            BGM.Play();
            attivato = true;
        }
        else if(SceneManager.GetActiveScene().buildIndex !=0 && attivato == true)
        {
            BGM.Stop();
            attivato = false;
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
}
