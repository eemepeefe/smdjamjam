using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour {
    public float movement;
    public float leftLimit;
    public float rightLimit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.A) && gameObject.transform.position.x > leftLimit)
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(-movement, 0f, 0f); 
        }
        if (Input.GetKeyUp(KeyCode.D) && gameObject.transform.position.x < rightLimit)
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(movement, 0f, 0f);
        }
    }
}
