using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MenuToggle : MonoBehaviour
{
    public GameObject menu; 
    private bool isMenuActive = false;
    private InputDevice leftController;

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

        if (leftController.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPressed))
        {
            
            if (isPressed)
            {
                ToggleMenu();
            }
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
