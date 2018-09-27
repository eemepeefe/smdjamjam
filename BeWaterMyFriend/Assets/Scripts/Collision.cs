using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {
    private GameObject mainCamera;
    public GameObject item;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AddLight")
        {
            Debug.Log("AddLight");
            GameObject.Find("GameController").GetComponent<GameController>().MoreIntensityLight();
        }
        if (other.tag == "LessLight")
        {
            Debug.Log("LessLight");
            GameObject.Find("GameController").GetComponent<GameController>().LessIntensityLight();
        }
        if (other.tag == "AddVel")
        {
            mainCamera.GetComponent<CameraMovement>().SetVelocity();
            Debug.Log("SetVelocity");
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
