using System.Collections;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
	public ParticleSystem system;
	public float delay = 1;

	IEnumerator Start ()
	{
		yield return new WaitForSecondsRealtime(delay);
		system.Pause(true);
	}
}
