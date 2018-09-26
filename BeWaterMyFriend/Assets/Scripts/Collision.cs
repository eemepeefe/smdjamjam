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
            foreach (Transform child in transform) {
                if(child.gameObject.tag == "Fish")
                {
                    child.gameObject.GetComponentInChildren<MaterialEmissionFish>().MoreIntensityLight();
                }
                else
                {
                    child.gameObject.GetComponent<MaterialEmission>().MoreIntensityLight();
                }
            }
        }
        if (other.tag == "LessLight")
        {
            Debug.Log("LessLight");
            foreach (Transform child in transform)
            {
                if (child.gameObject.tag == "Fish")
                {
                    child.gameObject.GetComponentInChildren<MaterialEmissionFish>().LessIntensityLight();
                }
                else
                {
                    child.gameObject.GetComponent<MaterialEmission>().LessIntensityLight();
                }
            }
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
