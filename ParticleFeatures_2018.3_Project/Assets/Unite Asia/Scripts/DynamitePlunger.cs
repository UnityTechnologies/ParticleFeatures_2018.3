using System.Collections;
using UnityEngine;

public class DynamitePlunger : MonoBehaviour
{
    public ParticleSystem[] particleSystems;
    public MeshRenderer mesh;
    public Material defaultPlunger;
    public Material mouseOverPlunger;
    public Animator animator;
    public ParticleSystem explosion;
    public float explodeDelay = 11.5f;

    private void OnMouseEnter()
    {
        mesh.material = mouseOverPlunger;
    }

    private void OnMouseExit()
    {
        mesh.material = defaultPlunger;
    }

    private void OnMouseUpAsButton()
    {
        explosion.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        animator.SetTrigger("PushPlunger");
    }

    public void LightFuses()
    {
        foreach (var system in particleSystems)
        {
            system.Play(true);
        }
        Invoke("Explode", explodeDelay);
    }

    void Explode()
    {
        explosion.Play(true);
    }
}
