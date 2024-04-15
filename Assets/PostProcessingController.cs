using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
    private PostProcessVolume _postProcessVolume;

    private Bloom _b;
    private DepthOfField _t;
    private ChromaticAberration _c;

    private int _BottleBloom;
    private int _BottleTrouble;
    private int _BottleChroma;
    private int _BottleMax;

    private void Start()
    {
        _postProcessVolume = GetComponent<PostProcessVolume>();
        _postProcessVolume.profile.TryGetSettings(out _b);
        _postProcessVolume.profile.TryGetSettings(out _t);
        _postProcessVolume.profile.TryGetSettings(out _c);

        _b.enabled.Override(true);
        _c.enabled.Override(true);
        _t.enabled.Override(true);

        _BottleBloom = PlayerInfo.Instance.BottleBloom;
        _BottleTrouble = PlayerInfo.Instance.BottleTrouble;
        _BottleChroma = PlayerInfo.Instance.BottleChroma;
        _BottleMax = PlayerInfo.Instance.BottleMax;
        Debug.Log("Initialized postprocessing");
    }

    private void Update()
    {
        if (_BottleBloom != PlayerInfo.Instance.BottleBloom)
        {
            Debug.Log("update bloom");
            _BottleBloom = PlayerInfo.Instance.BottleBloom;
            float b_intensity = _BottleBloom / _BottleMax;
            BloomSetOnVar(b_intensity);
        }
        if (_BottleTrouble != PlayerInfo.Instance.BottleTrouble)
        {
            _BottleTrouble = PlayerInfo.Instance.BottleTrouble;
            float t_intensity = _BottleTrouble / _BottleMax;
            TroubleSetOnVar(t_intensity);
        }
        if (_BottleChroma != PlayerInfo.Instance.BottleChroma)
        {
            _BottleChroma = PlayerInfo.Instance.BottleChroma;
            float c_intensity = _BottleChroma / _BottleMax;
            ChromaSetOnVar(c_intensity);
        }
    }

    public void BloomSetOnVar(float b_intensity)
    {
        // b_intensity is a value between 0 and 1
        if (b_intensity != 0)
        {
            Debug.Log(b_intensity.ToString());
            _b.active = true;
            _b.intensity.value = b_intensity * 100.0f;
            _b.threshold.value = 1.0f/b_intensity;
        }
        else
        {
            _b.active = false;
        }
    }

    public void TroubleSetOnVar(float t_intensity)
    {
        // t_intensity is a value between 0 and 1
        if (t_intensity != 0)
        {
            _t.active = true;
            _t.aperture.value = t_intensity*32.0f;
            _t.focusDistance.value = 20.0f * t_intensity;
            _t.focalLength.value = t_intensity * 75.0f;
        }
        else
        {
            _t.active = false;
        }
    }

    public void ChromaSetOnVar(float c_intensity)
    {
        // c_intensity is a value between 0 and 1
        if (c_intensity != 0)
        {
            _c.active = true;
            _c.intensity.value = c_intensity;
        }
        else
        {
            _c.active = false;
        }
    }

}

