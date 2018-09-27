using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour {
    public Sprite negro;
    public float seconds = 0.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
		
	}
    public void ChangeImage()
    {
        GameObject.Find("Background").GetComponent<Image>().sprite = negro;
        StartCoroutine(ChangeMainScene());
    }
    IEnumerator ChangeMainScene()
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(1);
    }
}
