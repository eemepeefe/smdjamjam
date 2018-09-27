using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour {
    public Sprite negro;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ChangeImage()
    {
        GameObject.Find("Background").GetComponent<Image>().sprite = negro;
        StartCoroutine(ChangeMainScene());
    }
    IEnumerator ChangeMainScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }
}
