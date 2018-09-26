using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {
    public float lightInstesity;
    public float lightRange;
    private Light lightMember;
	// Use this for initialization
	void Start () {
        lightMember = gameObject.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeLightIntensity(float intesity)
    {
        lightInstesity += intesity;
        lightMember.intensity = lightInstesity;
    }

    public void ChangeLightRange(float range)
    {
        lightRange += range;
        lightMember.range = lightRange;
    }
}
