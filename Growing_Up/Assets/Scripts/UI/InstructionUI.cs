using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InstructionUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _informationText;
    [SerializeField]
    private TextMeshProUGUI _headerText;

    public void SetupUI(string headerInformation, string information)
    {
        information = information.Replace("\\n", "\n");
        _headerText.text = headerInformation;
        _informationText.text = information;
    }
    public void EnableUI()
    {
        gameObject.SetActive(true);
    }

    public void DisableUI()
    {
        gameObject.SetActive(false);
    }
}
