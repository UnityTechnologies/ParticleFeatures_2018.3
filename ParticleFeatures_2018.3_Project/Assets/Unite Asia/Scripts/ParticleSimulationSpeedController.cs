using UnityEngine;
using UnityEngine.UI;

public class ParticleSimulationSpeedController : MonoBehaviour
{
    public Slider slider;
    public ParticleSystem[] particleSystems;
    public float startSpeed = 1;

    void OnEnable ()
    {
        SetSpeed(startSpeed);
        slider.value = startSpeed;
        slider.onValueChanged.AddListener(SetSpeed);
    }

    void OnDisable()
    {
        slider.onValueChanged.RemoveListener(SetSpeed);
    }

    void SetSpeed(float speed)
    {
        foreach (var system in particleSystems)
        {
            var main = system.main;
            main.simulationSpeed = speed;
        }
    }
}
