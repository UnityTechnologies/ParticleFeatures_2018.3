using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeParticles : MonoBehaviour
{
    Mesh bakedMesh;
    GameObject bakedMeshObject;
    public ParticleSystem system;
    public bool useTransform;

    void OnEnable()
    {
        bakedMesh = new Mesh();

        system.GetComponent<ParticleSystemRenderer>().BakeMesh(bakedMesh, useTransform); // Bake the mesh data
        //bakedMesh.UploadMeshData(true); // Save memory

        // Create our mesh version of the line
        var goMesh = new GameObject(name + "(Baked Mesh)");
        goMesh.AddComponent<MeshFilter>().sharedMesh = bakedMesh;
        goMesh.AddComponent<MeshRenderer>().sharedMaterial = system.GetComponent<ParticleSystemRenderer>().sharedMaterial;
        goMesh.AddComponent<MeshCollider>();

        //lineRenderer.enabled = false;
    }
}
