using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AlarmSounder))]

public class AlarmTrigger : MonoBehaviour
{
    private AlarmSounder _alarm;
    private bool _isPlayerInside;

    private void Start()
    {
        _alarm = GetComponent<AlarmSounder>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _isPlayerInside = true;
            _alarm.StartToPlay(_isPlayerInside);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _isPlayerInside = false;
            _alarm.EndToPlay(_isPlayerInside);
        }
    }
}
