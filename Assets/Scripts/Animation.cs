using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Animation : MonoBehaviour
{
    private const string Vertical = "Vertical";

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float zAxisMovement = Input.GetAxis(Vertical);

        _animator.SetFloat(PlayerAnimationController.Params.Vertical, zAxisMovement);
    }
}
