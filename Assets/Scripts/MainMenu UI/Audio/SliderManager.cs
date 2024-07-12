using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; set; }
    public AudioSource BGMAudioSource;
    public AudioSource SFXAudioSource;
    public Volumes sfx;
    public Volumes bgm;
    public Slider bgm_slider;
    public Slider sfx_slider;

    private void Awake()
    {
        if (instance != null && instance != this) { Destroy(this); }
        else { instance = this; }

        bgm.volume = BGMAudioSource.volume;
        bgm_slider.value = bgm.volume;

        sfx.volume = SFXAudioSource.volume;
        sfx_slider.value = sfx.volume;

    }

    private void Update()
    {
        BGMAudioSource.volume = bgm.volume;
        SFXAudioSource.volume = sfx.volume;
    }

    public void ChangeBGMVolume()
    {
        bgm.volume = bgm_slider.value;
        BGMAudioSource.volume = bgm.volume;
    }
    public void ChangeSFXVolume()
    {
        sfx.volume = sfx_slider.value;
        SFXAudioSource.volume = sfx.volume;
    }

}