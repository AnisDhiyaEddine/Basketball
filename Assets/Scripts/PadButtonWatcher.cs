using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

[System.Serializable]
public class PadButtonEvent : UnityEvent<bool> { }

public class PadButtonWatcher : MonoBehaviour
{
    public PadButtonEvent padButtonPress;

    private bool lastButtonState = false;
    private bool appState = true;

    private List<InputDevice> devicesWithPadButton;


    private void InputDevices_deviceConnected(InputDevice device)
    {
        bool discardedValue;
        if (device.TryGetFeatureValue(CommonUsages.menuButton, out discardedValue))
        {
            devicesWithPadButton.Add(device);
        }
    }

    private void InputDevices_deviceDisconnected(InputDevice device)
    {
        if (devicesWithPadButton.Contains(device))
        {
            devicesWithPadButton.Remove(device);
        }
    }

    private void RegisterDevices()
    {
        List<InputDevice> allDevices = new List<InputDevice>();
        InputDevices.GetDevices(allDevices);
        foreach (InputDevice device in allDevices)
            InputDevices_deviceConnected(device);
        InputDevices.deviceConnected += InputDevices_deviceConnected;
        InputDevices.deviceDisconnected += InputDevices_deviceDisconnected;
    }

    void Start()
    {
        devicesWithPadButton = new List<InputDevice>();
        RegisterDevices();
    }

    private void OnEnable()
    {
        RegisterDevices();
    }

    private void OnDisable()
    {
        InputDevices.deviceConnected -= InputDevices_deviceConnected;
        InputDevices.deviceDisconnected -= InputDevices_deviceDisconnected;
        devicesWithPadButton.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        bool tempState = false;
        foreach(var device in devicesWithPadButton)
        {
            bool primaryButtonState = false;
            tempState = device.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out primaryButtonState)
                && primaryButtonState
                || tempState;
        }

        if (tempState != lastButtonState)
        {
            if (tempState)
            {
                appState = !appState;
                padButtonPress.Invoke(appState);
            }
            lastButtonState = tempState;
        }
    }
}
