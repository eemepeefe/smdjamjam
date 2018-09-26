using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AddLight")
        {
            Debug.Log("AddLight");
        }
        if (other.tag == "LessLight")
        {
            Debug.Log("LessLight");
        }
        if (other.tag == "AddVel")
        {
            Debug.Log("AddVel");
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
