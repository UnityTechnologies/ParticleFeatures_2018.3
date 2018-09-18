using UnityEngine;

public class SpawnDecal : MonoBehaviour
{
    public ParticleSystem system;

    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                var ep = new ParticleSystem.EmitParams();
                ep.position = hit.point + (hit.normal * 1.1f); // Add a little offset to prevent z-fighting.
                ep.rotation3D = Quaternion.FromToRotation(Vector3.forward, hit.normal).eulerAngles;
                system.Emit(ep, 1);
            }
        }
    }
}
