using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class ShownewBindings : MonoBehaviour
{
    public InputActionReference moveActions;
    public InputActionReference interaction;

    public TextMeshProUGUI upText;
    public TextMeshProUGUI leftText;
    public TextMeshProUGUI rightText;
    public TextMeshProUGUI downText;
    public TextMeshProUGUI interactText;

    private void OnEnable()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        upText.text = $"{moveActions.action.GetBindingDisplayString(1)}";
        downText.text = $"{moveActions.action.GetBindingDisplayString(2)}";
        leftText.text = $"{moveActions.action.GetBindingDisplayString(3)}";
        rightText.text = $"{moveActions.action.GetBindingDisplayString(4)}";

        interactText.text = $"{interaction.action.GetBindingDisplayString(0)}";
    }
}
