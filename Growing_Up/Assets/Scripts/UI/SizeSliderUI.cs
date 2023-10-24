using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeSliderUI : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;
    void Start()
    {
        _slider.minValue = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
