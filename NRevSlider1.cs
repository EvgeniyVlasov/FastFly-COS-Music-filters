using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

public class NRevSlider1 : MonoBehaviour
{
    [SerializeField] float decayTime = 4;

    public void OnPointerDown(PointerEventData eventData)
    {
        //NReverbFilter.Instance.DecayTimeChange(decayTime);
    }
}
