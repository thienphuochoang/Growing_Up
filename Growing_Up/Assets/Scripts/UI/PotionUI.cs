using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PotionUI : MonoBehaviour
{
    private Player _player;
    [SerializeField] private TextMeshProUGUI _potionText;

    private void Start()
    {
        _player = PlayerManager.Instance.player.GetComponent<Player>();
        if (_player != null)
        {
            _player.OnNumberOfPotionChanged += UpdatePotionUI;
        }

        UpdatePotionUI();
    }

    private void UpdatePotionUI()
    {
        _potionText.text = "x " + _player.GetPotion().ToString();
    }
}
