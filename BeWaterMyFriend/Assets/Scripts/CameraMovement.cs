using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float velocity;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = gameObject.transform.position + new Vector3(0f, 0f, velocity);
	}
}
