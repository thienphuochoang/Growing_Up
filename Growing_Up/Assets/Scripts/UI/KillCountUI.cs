using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCountUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI killCountText;
    void Start()
    {
        GameManager.Instance.OnEnemyKill += UpdateKillCountUI;
        UpdateKillCountUI();
    }
    
    private void UpdateKillCountUI()
    {
        killCountText.text = "x " + GameManager.Instance.EnemyKillCount;
    }
}
