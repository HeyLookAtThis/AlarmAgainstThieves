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

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
        _sound.volume = _minVolume;
    }

    public void StartToPlay(bool trigger)
    {
        _sound.Play();

        StartCoroutine(ChangeVolume(trigger));
    }

    public void EndToPlay(bool trigger)
    {
        StartCoroutine(ChangeVolume(trigger));

        if (_sound.volume == _minVolume)
            _sound.Stop();
    }

    private float GetTargetVolume(bool trigger)
    {
        return trigger ? _maxVolume : _minVolume;
    }    

    private IEnumerator ChangeVolume(bool trigger)
    {
        float waitTime = 0.2f;
        var waitForSeconds = new WaitForSeconds(waitTime);

        float triggerVolume = GetTargetVolume(trigger);
        float volumeChanger = 0.05f;

        for(float i = _sound.volume; i!= triggerVolume;)
        {
            _sound.volume = Mathf.MoveTowards(_sound.volume, triggerVolume, volumeChanger);

            yield return waitForSeconds;

            if (_sound.volume == triggerVolume)
                yield break;
        }
    }
}