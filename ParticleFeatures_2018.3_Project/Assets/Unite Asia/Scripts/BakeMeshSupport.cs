using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class BakeMeshSupport : MonoBehaviour
{
    Mesh bakedMesh;
    GameObject bakedMeshObject;

	void OnEnable()
	{
        // We could use this approach to generate multiple LODS using the LineUtility class.
        var lineRenderer = GetComponent<LineRenderer>();
        bakedMesh = new Mesh();

        lineRenderer.BakeMesh(bakedMesh, true); // Bake the mesh data
        bakedMesh.UploadMeshData(true); // Save memory

        // Create our mesh version of the line
        var goMesh = new GameObject(name + "(Baked Mesh)");
        goMesh.AddComponent<MeshFilter>().sharedMesh = bakedMesh;
        goMesh.AddComponent<MeshRenderer>().sharedMaterial = lineRenderer.sharedMaterial;
        goMesh.AddComponent<MeshCollider>();

        lineRenderer.enabled = false;
	}

	void OnDisable()
	{
        if (bakedMeshObject)
            Destroy(bakedMeshObject);

        if (bakedMesh)
            Destroy(bakedMesh);
        
        var lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = true;
	}
}
