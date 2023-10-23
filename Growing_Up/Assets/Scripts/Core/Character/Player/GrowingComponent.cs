using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingComponent : MonoBehaviour
{
    [SerializeField]
    private bool _isGrowing = false;

    private Player _player;

    private float _scaleFactor = 0.0001f;
    private Vector3 _initialScale;

    private void Start()
    {
        _initialScale = transform.localScale;
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (_isGrowing)
            Growing();
    }
    private void Growing()
    {
        Vector3 newScale = transform.localScale + new Vector3(_scaleFactor, _scaleFactor, _scaleFactor);
        transform.localScale = newScale;
        // TODO: Need to scale the ground distance check and wall check
        //_player.groundCheckDistance += _scaleFactor;
        //_player.wallCheckDistance += _scaleFactor;
    }
}
