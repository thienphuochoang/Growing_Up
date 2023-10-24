using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("Idle", true);
    }

    public void Break()
    {
        _animator.SetBool("Idle", false);
        _animator.SetTrigger("Destroy");
    }

    private void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}
