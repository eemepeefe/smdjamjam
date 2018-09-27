using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float velocity;
    public float timeToReduce;
    private bool velDoble;
	// Use this for initialization
	void Start () {
        velDoble = false;
        StartCoroutine(AddDificulty());
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = gameObject.transform.position + new Vector3(0f, 0f, velocity);
	}
    public void SetVelocity()
    {
        if (!velDoble)
        {
            velocity *= 3;
            velDoble = true;
            StartCoroutine(ReduceVel());
        }
        
    }

    IEnumerator ReduceVel()
    {
        yield return new WaitForSeconds(timeToReduce);
        velDoble = false;
        velocity /= 3;
    }

    IEnumerator AddDificulty()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            velocity += 0.03f;
        }
       
    }
}
