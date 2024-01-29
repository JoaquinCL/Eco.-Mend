using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider sliderMusic, sliderSFX, sliderDialogues;
    public string mixerMusicParameter = "VolumeMusic";
    public string mixerSFXParameter = "VolumeSFX";
    public string mixerDialoguesParameter = "VolumeDialogues";
    private const string prefKeyMusic = "volumeMusic";
    private const string prefKeySFX = "volumeSFX";
    private const string prefKeyDialogues = "volumeDialogues";

    private void Awake()
    {
        sliderMusic.onValueChanged.AddListener(ChangeMusicVolume);
        sliderSFX.onValueChanged.AddListener(ChangeSFXVolume);
        sliderDialogues.onValueChanged.AddListener(ChangeDialoguesVolume);
    }

    private void Start()
    {
        float valueMusic = PlayerPrefs.GetFloat(prefKeyMusic, 1f);
        float valueSFX = PlayerPrefs.GetFloat(prefKeySFX, 1f);
        float valueDialogues = PlayerPrefs.GetFloat(prefKeyDialogues, 1f);
        sliderMusic.value = valueMusic;
        sliderSFX.value = valueSFX;
        sliderDialogues.value = valueDialogues;
        ChangeMusicVolume(valueMusic);
        ChangeSFXVolume(valueSFX);
        ChangeDialoguesVolume(valueDialogues);
    }

    public void ChangeMusicVolume(float value)
    {
        value = Mathf.Clamp(value, 0.0001f, 1f);
        audioMixer.SetFloat(mixerMusicParameter, Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat(prefKeyMusic, value);
    }

    public void ChangeSFXVolume(float value)
    {
        value = Mathf.Clamp(value, 0.0001f, 1f);
        audioMixer.SetFloat(mixerSFXParameter, Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat(prefKeySFX, value);
    }

    public void ChangeDialoguesVolume(float value)
    {
        value = Mathf.Clamp(value, 0.0001f, 1f);
        audioMixer.SetFloat(mixerDialoguesParameter, Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat(prefKeyDialogues, value);
    }
}