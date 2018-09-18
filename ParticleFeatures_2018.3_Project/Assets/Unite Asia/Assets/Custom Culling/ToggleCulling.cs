using UnityEngine;

public class ToggleCulling : MonoBehaviour
{
	CustomParticleCulling[] m_Culling;

	void Start ()
	{
		m_Culling = FindObjectsOfType<CustomParticleCulling>();
	}

	public bool culling
	{
	    set
	    {
	        foreach (var customParticleCulling in m_Culling)
	        {
	            customParticleCulling.enabled = value;
	        }
	    }
	}
}
