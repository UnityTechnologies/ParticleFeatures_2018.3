using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CullingStats : MonoBehaviour
{
	public Text text;
	CustomParticleCulling[] m_Culling;
	ParticleSystem[] m_Systems;

	void Start()
	{
		m_Culling = FindObjectsOfType<CustomParticleCulling>();
		m_Systems = FindObjectsOfType<ParticleSystem>();
	}

	void Update ()
	{
		int active = m_Systems.Count(ps => !ps.isPaused);
		text.text = string.Format("Active Particle Systems {0}/{1}", active, m_Systems.Length);
	}
}
