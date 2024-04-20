using ARSIS.EventManager;
using MixedReality.Toolkit.UX;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/**
 * This script is to be placed at the root gameObject of the SettingsWindow variant prefab.
 */
public class SettingsWindow : MonoBehaviour
{
    [SerializeField] MRTKUGUIInputField inputField;
    private TouchScreenKeyboard keyboard;

    public void OpenSystemKeyboard()
    {
        keyboard = TouchScreenKeyboard.Open(inputField.text, TouchScreenKeyboardType.URL, false, false, false, false);
    }

    void Start()
    {
        EventManager instance = EventManager.Instance;
        inputField.text = instance.Endpoint;
    }

    public void SetEVA(int eva)
    {
        EventManager instance = EventManager.Instance;
        instance.Eva = eva;
    }

    public void SetEndpoint()
    {
        EventManager instance = EventManager.Instance;
        instance.Endpoint = inputField.text;
    }

    public void RestartClient()
    {
        EventManager instance = EventManager.Instance;
        instance.EndClient();
        instance.StartClient();
    }

    private void Update()
    {
        if (keyboard == null) return;
        inputField.text = keyboard.text;
        if (keyboard.status == TouchScreenKeyboard.Status.Done)
            keyboard = null;
    }
}
