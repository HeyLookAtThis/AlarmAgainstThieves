using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float zAxisMovement = Input.GetAxis("Vertical");

        _animator.SetFloat("Vertical", zAxisMovement);
    }
}
