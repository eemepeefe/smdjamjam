using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MaterialEmission : MonoBehaviour {
    Material mat;
    public Texture emissive;
    private GameObject mainCharacter;
    public float leftLimit;
    public float rightLimit;
    private string name;
	// Use this for initialization
	void Start () {
        name = gameObject.name.Replace("(Clone)","");
        emissive = Resources.Load<Texture>(name);
        mat = GetComponent<Renderer>().material;
        mat.EnableKeyword("_EMISSION");
        mat.SetTexture("_EmissionMap", emissive);
        mat.SetColor("_EmissionColor", Color.white);
        mainCharacter = GameObject.Find("spot_light");
    }
	
	// Update is called once per frame
	void Update () {
		
    }
}
