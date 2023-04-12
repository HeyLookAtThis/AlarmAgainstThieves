using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlarmSounder : MonoBehaviour
{
    [HideInInspector] private AudioSource _sound;
    private PlayerTrigger _trigger;

    private float _minVolume = 0.0f;
    private float _maxVolume = 1.0f;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
        _trigger = GetComponent<PlayerTrigger>();
        _sound.volume = _minVolume;
    }

    private void Update()
    {
        if (_trigger.IsInside == true)
            BeginToPlay();
        else
            EndToPlay();
    }

    private void BeginToPlay()
    {
        if (_sound.isPlaying == false)
            _sound.Play();

        _sound.volume = MakeLouder();
    }

    private void EndToPlay()
    {
        _sound.volume = MakeQuieter();

        if (_sound.volume == _minVolume)
            _sound.Stop();
    }

    private float MakeQuieter()
    {
        return Mathf.MoveTowards(_sound.volume, _minVolume, Time.deltaTime);
    }

    private float MakeLouder()
    {
        return Mathf.MoveTowards(_sound.volume, _maxVolume, Time.deltaTime);
    }
}