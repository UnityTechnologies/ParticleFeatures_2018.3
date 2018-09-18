using UnityEngine;
using UnityEngine.AI;

public class RingbufferFootSteps : MonoBehaviour
{
    public ParticleSystem system;
    public NavMeshAgent agent;
    public Material activeMat;
    public Material selectedMat;
    public Material activeParticleMat;
    public Material selectedParticleMat;
    public ParticleSystem clickEffect;

    Vector3 lastEmit;

    public float delta = 1;
    public float gap = 0.5f;
    int dir = 1;
    static RingbufferFootSteps selectedSystem;

    void Start()
    {
        lastEmit = transform.position;
        GetComponent<MeshRenderer>().material = activeMat;
    }

    public void Update()
    {
        if (selectedSystem == this && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                agent.isStopped = false;
                agent.SetDestination(hit.point);
                clickEffect.transform.position = hit.point;
                clickEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                clickEffect.Play(true);
                //clickEffect.GetComponent<Animator>().SetTrigger("grow");
            }
        }

        if (Vector3.Distance(lastEmit, transform.position) > delta)
        {
            Gizmos.color = Color.green;
            var pos = transform.position + (transform.right * gap * dir);
            dir *= -1;
            ParticleSystem.EmitParams ep = new ParticleSystem.EmitParams();
            ep.position = pos;
            ep.rotation = transform.rotation.eulerAngles.y;
            system.Emit(ep, 1);
            lastEmit = transform.position;
        }

    }

    public void OnMouseUpAsButton()
    {
        if (selectedSystem == this)
            return;

        if (selectedSystem != null)
        {
            selectedSystem.agent.isStopped = true;
            selectedSystem.GetComponent<Renderer>().material = activeMat;
            selectedSystem.system.GetComponent<Renderer>().material = activeParticleMat;
        }

        selectedSystem = this;
        GetComponent<Renderer>().material = selectedMat;
        system.GetComponent<Renderer>().material = selectedParticleMat;
    }
}
