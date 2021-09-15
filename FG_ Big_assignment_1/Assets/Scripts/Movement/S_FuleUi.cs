using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_FuleUi : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Gradient gradient;
    [SerializeField] Image fill;

    public void SetMaxFule(float fule)
    {
        slider.maxValue = fule;
        slider.value = fule;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetFule(float fule)
    {
        slider.value = fule;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
