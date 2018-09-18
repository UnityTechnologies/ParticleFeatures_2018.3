using UnityEngine;

public class CustomParticleCulling : MonoBehaviour
{
    public float cullingRadius = 10;
    public ParticleSystem target;

    CullingGroup m_CullingGroup;
    Renderer[] m_ParticleRenderers;

    void OnEnable()
    {
        // Do we need custom culling?
        if (target.automaticCullingEnabled)
        {
            Debug.Log(name + " does not need custom culling");
            enabled = false;
            return;
        }

        if(m_ParticleRenderers == null)
            m_ParticleRenderers = target.GetComponentsInChildren<Renderer>();

        if (m_CullingGroup == null)
        {
            m_CullingGroup = new CullingGroup();
            m_CullingGroup.targetCamera = Camera.main;
            m_CullingGroup.SetBoundingSpheres(new[] { new BoundingSphere(transform.position, cullingRadius) });
            m_CullingGroup.SetBoundingSphereCount(1);
            m_CullingGroup.onStateChanged += OnStateChanged;
        }

        // We need to sync the culled state.
        Cull(m_CullingGroup.IsVisible(0));
        m_CullingGroup.enabled = true;
    }

    void OnDisable()
    {
        if(m_CullingGroup != null)
            m_CullingGroup.enabled = false;

        target.Play(true);
        SetRenderers(true);
    }

    void OnDestroy()
    {
        if (m_CullingGroup != null)
            m_CullingGroup.Dispose();
    }

    void OnStateChanged(CullingGroupEvent sphere)
    {
        Cull(sphere.isVisible);
    }

    void Cull(bool visible)
    {
        if(visible)
        {
            // We could simulate forward a little here to hide that the system was not updated off-screen.
            target.Play(true);
            SetRenderers(true);
        }
        else
        {
            target.Pause(true);
            SetRenderers(false);
        }
    }

    void SetRenderers(bool enable)
    {
        // We also need to disable the renderer to prevent drawing the particles, such as when occlusion occurs.
        foreach (var particleRenderer in m_ParticleRenderers)
        {
            particleRenderer.enabled = enable;
        }
    }

    void OnDrawGizmos()
    {
        if (enabled)
        {
            // Draw gizmos to show the culling sphere.
            Color col = Color.yellow;
            if (m_CullingGroup != null && !m_CullingGroup.IsVisible(0))
                col = Color.gray;

            Gizmos.color = col;
            Gizmos.DrawWireSphere(transform.position, cullingRadius);
        }
    }
}