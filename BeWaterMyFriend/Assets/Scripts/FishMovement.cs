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
        
    }
    public void SetFishLeftPosition()
    {
        if(gameObject.transform.position.x > leftLimit)
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(-movement, 0f, 0f);
        }
    }
    public void SetFishRightPosition()
    {
        if (gameObject.transform.position.x < rightLimit)
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(movement, 0f, 0f);
        }
    }
}
