using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingComponent : MonoBehaviour
{
    [SerializeField]
    private bool _isGrowing = false;

    private Player _player;

    private float _scaleFactor = 0.0004f;
    private Vector3 _initialScale;
    private float _initialGroundCheckDistance;
    private float _initialWallCheckDistance;
    private float _initialAttackCheckRadius;
    private void Start()
    {
        _initialScale = transform.localScale;
        _player = GetComponent<Player>();
        _initialGroundCheckDistance = _player.groundCheckDistance;
        _initialWallCheckDistance = _player.wallCheckDistance;
        _initialAttackCheckRadius = _player.attackCheckRadius;
        _player.OnPotionConsumed += BackToOriginalSize;
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
        float scaleMultiplier = 1.0f + _scaleFactor;
        _player.groundCheckDistance *= scaleMultiplier;
        _player.wallCheckDistance *= scaleMultiplier;
        _player.attackCheckRadius *= scaleMultiplier - 0.0001f;
    }

    private void BackToOriginalSize()
    {
        _isGrowing = false;
        transform.localScale = _initialScale;
        _player.groundCheckDistance = _initialGroundCheckDistance;
        _player.wallCheckDistance = _initialWallCheckDistance;
        _player.attackCheckRadius = _initialAttackCheckRadius;
        GameManager.Instance.canBreakObjects = false;
    }

    public void EnableGrowing()
    {
        _isGrowing = true;
    }
}
