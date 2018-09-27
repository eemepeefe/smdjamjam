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
            Destroy(other.gameObject);
        }
        if (other.tag == "LessLight")
        {
            Debug.Log("LessLight");
            GameObject.Find("GameController").GetComponent<GameController>().LessIntensityLight();
            Destroy(other.gameObject);
        }
        if (other.tag == "AddVel")
        {
            mainCamera.GetComponent<CameraMovement>().SetVelocity();
            Debug.Log("SetVelocity");
            Destroy(other.gameObject);
        }
        if(other.tag == "Shark")
        {
            Debug.Log("GameOver");
            Destroy(other.gameObject);
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
