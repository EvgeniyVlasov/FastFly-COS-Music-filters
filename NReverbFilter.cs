using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Unity.VisualScripting;

public class NReverbFilter : MonoBehaviour
{

    //[SerializeField] private AudioSource _musicSource;

    //[SerializeField] private Slider _slider;


    // T60 decay time.
    [Range(0.0f, 4.0f)] public float decayTime = 1.0f;

    // Send/return level.
    [Range(0.0f, 1.0f)] public float sendLevel = 0.1f;

    // STK NReverb filter.
    Stk.NReverb reverb;

    // Used for detecting parameter changes.
    float prevDecayTime;

    // Used for error handling.
    string error;

    //public static NReverbFilter Instance;

    public void Awake()
    {
        reverb = new Stk.NReverb(decayTime);
        prevDecayTime = decayTime;
    }

    void Update()
    {
        if (error == null)
        {
            if (decayTime != prevDecayTime)
            {
                reverb.DecayTime = decayTime;
                prevDecayTime = decayTime;
            }
        }
        else
        {
            Debug.LogError(error);
            Destroy(this);
        }
    }

    public void DecayTimeChange (float val)
    {
        decayTime = val;
        //_slider.onValueChanged.AddListener(prevDecayTime);
    }

    public void OnAudioFilterRead(float[] data, int channels)
    {
        if (channels != 2)
        {
            error = "This filter only supports stereo audio (given:" + channels + ")";
            return;
        }
        for (var i = 0; i < data.Length; i += 2)
        {
            var output = reverb.Tick(0.2f * (data[i] + data[i + 1]));
            data[i] += output.left * sendLevel;
            data[i + 1] += output.right * sendLevel;
        }
    }
}
