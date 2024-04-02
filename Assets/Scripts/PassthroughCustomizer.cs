using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassthroughCustomizer : MonoBehaviour
{
    [SerializeField] private OVRPassthroughLayer passthroughLayer1;
    [SerializeField] private OVRPassthroughLayer passthroughLayer2;
    private bool isLayerActive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerPressure = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        if (isLayerActive)
        {
            passthroughLayer1.SetBrightnessContrastSaturation(0, triggerPressure, 0);
        }
        else
        {
            passthroughLayer2.SetBrightnessContrastSaturation(triggerPressure, 0, 0);
        }

        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            ToggleEnableDisableLayer();
            //ToggleCompositionDepth();
        }
    }

    private void ToggleCompositionDepth()
    {
        // Swap the composition depth of the two layers and update the active layer
        int tempDepth = passthroughLayer1.compositionDepth;
        passthroughLayer1.compositionDepth = passthroughLayer2.compositionDepth;
        passthroughLayer2.compositionDepth = tempDepth;

        // Update the active layer flag
        isLayerActive = !isLayerActive;
    }
     private void ToggleEnableDisableLayer()
    {
        // Disable the currently active layer and enable the other one
        if (isLayerActive)
        {
            passthroughLayer1.enabled = false;
            passthroughLayer2.enabled = true;
        }
        else
        {
            passthroughLayer1.enabled = true;
            passthroughLayer2.enabled = false;
        }

        // Update the active layer flag
        isLayerActive = !isLayerActive;
    }
}
