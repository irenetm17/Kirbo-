using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Options : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions; 
    
    void Start()
    {

        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;

        List<string> options = new List<string>();

        int i = 0; 

        foreach (Resolution resolution in Screen.resolutions)
        {
            string option = resolution.width + "x" + resolution.height;
            options.Add(option);

            if (resolution.width == Screen.currentResolution.width && resolution.height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
            i++;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetFullScreen (bool isFullsScreen)
    {
        Screen.fullScreen = isFullsScreen;
    }


}
