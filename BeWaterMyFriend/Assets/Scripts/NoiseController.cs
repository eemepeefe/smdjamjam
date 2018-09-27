using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseController : MonoBehaviour {

    public Material mat;
    float x = 1.0f;
    float y = 1.0f;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        x = x + Random.Range(0, Time.deltaTime);
        y = y + Random.Range(0, Time.deltaTime);
        mat.SetFloat("_X", x);
        mat.SetFloat("_Y", x);


    }
}
