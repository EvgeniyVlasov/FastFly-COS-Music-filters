using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NRevSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    void Start()
    {
        //_slider.onValueChanged.AddListener(val => NReverbFilter.Instance.DecayTimeChange(val));
    }
}
