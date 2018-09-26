using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {
    private GameObject mainCamera;
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
            mainCamera.GetComponent<CameraMovement>().SetVelocity();
        }
        if(other.tag == "Shark")
        {
            Debug.Log("GameOver");
        }
    }

    // Use this for initialization
    void Start () {
        mainCamera = GameObject.Find("Main Camera");

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
