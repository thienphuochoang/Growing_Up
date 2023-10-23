using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingComponent : MonoBehaviour
{
    [SerializeField]
    private bool _isGrowing = false;

    private float _scaleFactor = 0.01f;
    private Vector3 _initialScale;

    private void Start()
    {
        _initialScale = transform.localScale;
    }

    private void Update()
    {
        Growing();
    }
    private void Growing()
    {
        Vector3 newScale = transform.localScale + new Vector3(_scaleFactor, _scaleFactor, _scaleFactor);
        transform.localScale = newScale;
    }
}
