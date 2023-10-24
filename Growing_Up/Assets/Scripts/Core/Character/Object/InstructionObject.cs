using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionObject : MonoBehaviour
{
    [SerializeField]
    private string _heading;
    [SerializeField]
    private string _information;
    [SerializeField]
    private GameObject _instructionHolderObject;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
        {
            _instructionHolderObject.GetComponent<InstructionUI>().SetupUI(_heading, _information);
            _instructionHolderObject.GetComponent<InstructionUI>().EnableUI();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
        {
            _instructionHolderObject.GetComponent<InstructionUI>().DisableUI();
        }
    }
}
