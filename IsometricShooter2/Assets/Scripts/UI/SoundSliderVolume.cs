using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSliderVolume : MonoBehaviour
{
    private AudioSource[] audioSources;
    private float volume;

    void Start()
    {
        audioSources = FindObjectsOfType<AudioSource>();
        volume = 1;
        gameObject.GetComponent<Slider>().value = volume;
    }

    void Update()
    {
        SetVolumes();
    }

    private void SetVolumes()
    {
        volume = gameObject.GetComponent<Slider>().value;
        foreach (AudioSource source in audioSources)
        {
            source.volume = volume;
        }
    }
}
