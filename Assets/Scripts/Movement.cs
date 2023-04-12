using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector3 _playerVelocity;
    private float _speed = 5.0f;
    private float _gravitationalForce = -9.81f;

    private void Start()
    {
        _characterController = gameObject.AddComponent<CharacterController>();
        _characterController.height = 0;
    }

    private void Update()
    {
        float zAxisDirection = Input.GetAxis("Vertical");

        Vector3 travelDirection = transform.forward * zAxisDirection;

        _characterController.Move(travelDirection * _speed * Time.deltaTime);

        _playerVelocity.y += _gravitationalForce * Time.deltaTime;

        _characterController.Move(_playerVelocity *  Time.deltaTime);
    }

}
