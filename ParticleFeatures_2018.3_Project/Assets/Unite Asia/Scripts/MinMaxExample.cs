using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMaxExample : MonoBehaviour 
{
    public ParticleSystem.MinMaxGradient minMaxGradient;
    public ParticleSystem.MinMaxCurve minMaxCurve;

    void Start()
    {
        float value = minMaxCurve.Evaluate(Time.time);
    }
}
