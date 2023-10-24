using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowUI : MonoBehaviour
{
    private Player _player;
    public Slider slider;
    public RectTransform keepTrackingArrow;
    public Image breakableObjectArrow; 
    public Image suddenDeathArrow;
    private void Start()
    {
        _player = PlayerManager.Instance.player;
        slider.minValue = _player.transform.localScale.x;
        slider.maxValue = GameManager.Instance.maxSizeAllowed;
    }

    private void Update()
    {
        slider.value = _player.transform.localScale.x;
    }

    public void UpdateArrowPosition()
    {
        // Calculate the position of the arrow based on the slider's value.
        float arrowMinX = keepTrackingArrow.rect.width / 2;
        float arrowMaxX = slider.GetComponent<RectTransform>().rect.width - arrowMinX;
        float arrowX = Mathf.Lerp(arrowMinX, arrowMaxX, (slider.value - slider.minValue) / (slider.maxValue - slider.minValue));

        // Update the arrow's position.
        Vector3 arrowPosition = keepTrackingArrow.localPosition;
        arrowPosition.x = arrowX;
        keepTrackingArrow.localPosition = arrowPosition;
        if (keepTrackingArrow.localPosition.x > breakableObjectArrow.rectTransform.localPosition.x)
        {
            GameManager.Instance.canBreakObjects = true;
        }
        if (keepTrackingArrow.localPosition.x > suddenDeathArrow.rectTransform.localPosition.x)
        {
            GameManager.Instance.suddenDeath = true;
        }
    }
}
