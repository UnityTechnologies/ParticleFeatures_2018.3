

using UnityEngine;

public class Rotate : MonoBehaviour {

    public Vector3 axis = Vector3.up;
    public float speed = 10f; 

	// Update is called once per frame
	void Update () {
        transform.Rotate(axis, speed * Time.deltaTime);	
	}
}
