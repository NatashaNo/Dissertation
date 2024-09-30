using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MenuToggle : MonoBehaviour
{
    public GameObject menu;
    private bool isMenuActive = false;
    private InputDevice leftController;
    private bool wasPressed = false; // To handle button press state

    void Start()
    {
        GetLeftController();
        menu.SetActive(false);
    }

    void Update()
    {
        if (!leftController.isValid)
        {
            GetLeftController();
        }

        // Check if primary button is pressed
        if (leftController.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPressed))
        {
            // Only toggle if the button was not previously pressed
            if (isPressed && !wasPressed)
            {
                ToggleMenu();
            }
            // Update wasPressed state
            wasPressed = isPressed;
        }
    }

    private void GetLeftController()
    {
        var leftHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, leftHandDevices);

        if (leftHandDevices.Count > 0)
        {
            leftController = leftHandDevices[0];
        }
    }

    private void ToggleMenu()
    {
        isMenuActive = !isMenuActive;
        menu.SetActive(isMenuActive);
    }
}