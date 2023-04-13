using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlarmSounder : MonoBehaviour
{
    private AudioSource _sound;
    private PlayerTrigger _trigger;

    private float _minVolume = 0.0f;
    private float _maxVolume = 1.0f;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
        _trigger = GetComponent<PlayerTrigger>();
        _sound.volume = _minVolume;
        _sound.Play();
    }

    private void Update()
    {
        float triggerVolume = GetTargetVolume(_trigger.IsInside);

        _sound.volume = ChangeVolume(triggerVolume);
    }

    private float GetTargetVolume(bool trigger)
    {
        return trigger ? _maxVolume : _minVolume;
    }
    
    private float ChangeVolume(float targetVolume)
    {
        return Mathf.MoveTowards(_sound.volume, targetVolume, Time.deltaTime);
    }
}