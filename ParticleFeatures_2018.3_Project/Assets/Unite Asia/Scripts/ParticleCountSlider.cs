using UnityEngine;
using UnityEngine.UI;

public class ParticleCountSlider : MonoBehaviour
{
	public Gradient gradient;
	public Slider slider;
	public Image capacityImage;
	public ParticleSystem system;

	void Update ()
	{
		var ratio  = system.particleCount / (float)system.main.maxParticles;
		var col = gradient.Evaluate(ratio);
		capacityImage.color = col;
		slider.value = ratio;
	}
}
