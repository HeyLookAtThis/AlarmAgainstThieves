using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private const string MouseX = "Mouse X";

    private float _rotationSpeed = 2.0f;
    private float _yAxisVolume;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _yAxisVolume += _rotationSpeed * Input.GetAxis(MouseX);
        transform.eulerAngles = new Vector3(0, _yAxisVolume, 0);
    }
}
