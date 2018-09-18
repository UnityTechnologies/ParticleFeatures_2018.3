using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillate : MonoBehaviour {

    public Vector3 axis = new Vector3(0, 1, 0);
    public float range = 30f;
    public float speed = 1f;

	// Use this for initialization
	IEnumerator Start ()
    {
        bool goingUp = true;
        float curRot = 0f;
        Vector3 startRot = transform.localRotation.eulerAngles;

        while (true)
        {
           curRot += goingUp ? Time.deltaTime * speed : Time.deltaTime * speed * -1;

            //change direction
            if (goingUp && curRot > range)
                goingUp = false;

            if (!goingUp && curRot < -range)
                goingUp = true;

            transform.localRotation = Quaternion.Euler(startRot + axis * curRot);
           yield return null;
        }
	}

}
