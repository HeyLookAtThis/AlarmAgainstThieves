using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmPoint : MonoBehaviour
{
    [HideInInspector] private AudioSource _audioSource;

    private float _minVolume = 0.0f;
    private float _maxVolume = 1.0f;
    private bool _isPlayerInside;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    private void Update()
    {
        if (_isPlayerInside)
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, Time.deltaTime);

        if (_isPlayerInside == false && _audioSource.volume > _minVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _minVolume, Time.deltaTime);

            if (_audioSource.volume == _minVolume)
                _audioSource.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _isPlayerInside = true;
            _audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent<Player>(out Player player) )
            _isPlayerInside = false;
    }
}
