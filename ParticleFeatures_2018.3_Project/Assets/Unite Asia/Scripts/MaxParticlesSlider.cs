using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxParticlesSlider : MonoBehaviour
{
    public Slider slider;
    public ParticleSystem system;
    public Text label;
    ParticleSystem.MainModule m_MainModule;

    private void OnEnable()
    {
        m_MainModule = system.main;
        slider.value = m_MainModule.maxParticles;
        slider.onValueChanged.AddListener(ValueChanged);
        label.text = m_MainModule.maxParticles.ToString();
    }

    private void OnDisable()
    {
        slider.onValueChanged.RemoveListener(ValueChanged);
    }

    void ValueChanged(float val)
    {
        m_MainModule.maxParticles = (int)val;
        label.text = m_MainModule.maxParticles.ToString();
    }
}
