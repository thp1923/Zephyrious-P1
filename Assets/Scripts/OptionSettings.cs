using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionSettings : MonoBehaviour
{
    Resolution[] resolutions;
    public Dropdown ResolutionSettings;
    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        ResolutionSettings.ClearOptions();
        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
        }
        ResolutionSettings.AddOptions(options);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
