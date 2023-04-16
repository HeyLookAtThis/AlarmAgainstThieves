using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AlarmSounder : MonoBehaviour
{
    private AudioSource _sound;
    private float _minVolume = 0.0f;
    private float _maxVolume = 1.0f;
    private Coroutine _volumeChanger;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
        _sound.volume = _minVolume;
    }

    public void StartToPlay(bool trigger)
    {
        _sound.Play();

        StartVolumeChanger(trigger);
    }

    public void EndToPlay(bool trigger)
    {
        StartVolumeChanger(trigger);

        StartCoroutine(StopSound());
    }

    private void StartVolumeChanger(bool trigger)
    {
        if (_volumeChanger != null)
            StopCoroutine(_volumeChanger);

        _volumeChanger = StartCoroutine(ChangeVolume(trigger));
    }

    private float GetTargetVolume(bool trigger)
    {
        return trigger ? _maxVolume : _minVolume;
    }

    private IEnumerator ChangeVolume(bool trigger)
    {
        float waitTime = 0.2f;
        var waitForSeconds = new WaitForSeconds(waitTime);
        float volumeChanger = 0.05f;

        float targetVolume = GetTargetVolume(trigger);

        while (_sound.volume != targetVolume)
        {
            _sound.volume = Mathf.MoveTowards(_sound.volume, targetVolume, volumeChanger);
            yield return waitForSeconds;
        }

        if (_sound.volume == targetVolume)
            yield break;
    }

    private IEnumerator StopSound()
    {
        while (_sound.isPlaying)
        {
            if (_sound.volume == _minVolume)
            {
                _sound.Stop();
                yield break;
            }
            else
            {
                yield return null;
            }
        }
    }
}