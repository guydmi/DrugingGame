using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
    private PostProcessVolume _postProcessVolume;
    private Bloom _b;

    private void Start()
    {
        _postProcessVolume = GetComponent<PostProcessVolume>();
        _postProcessVolume.profile.TryGetSettings(out _b);
        _b.active = true;
        _b.intensity.value = 25.0f;
        _b.threshold.value = 0.02f;

    }

    public void BloomOnOff(bool on)
    {
        if (on)
        {
            _b.active = true;
        }
        else
        {
            _b.active = false;
        }
    }

}

