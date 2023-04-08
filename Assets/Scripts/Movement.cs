using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float _speed = 3.0f;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        int negativeCoefficient = -1;

        float forewardRunSpeed = _speed * Time.deltaTime;
        float backwardRunSpeed = _speed * Time.deltaTime * negativeCoefficient;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, forewardRunSpeed);
            _animator.SetBool("IsWKeyPressing", true);
        }
        else
        {
            _animator.SetBool("IsWKeyPressing", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, backwardRunSpeed);
            _animator.SetBool("IsSKeyPressing", true);
        }
        else
        {
            _animator.SetBool("IsSKeyPressing", false);
        }
    }
}
