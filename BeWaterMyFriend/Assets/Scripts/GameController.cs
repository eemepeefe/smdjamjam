using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject fish;
    FishMovement fishScript;
    // Use this for initialization
    void Start () {
        fishScript = fish.GetComponent<FishMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.A) )
        {
            fishScript.SetFishLeftPosition();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            fishScript.SetFishRightPosition();
        }
        
    }
}
