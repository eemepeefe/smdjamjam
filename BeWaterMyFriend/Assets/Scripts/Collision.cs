using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour {
    private GameObject mainCamera;
    public GameObject item;
    public AudioClip trashAudio;
    public AudioClip sharkAudio;
    public AudioClip velAudio;
    public AudioClip lightAudio;
    public GameObject velParticles;
    public GameObject ligthParticles;
    private GameObject particleGameObject;

    AudioSource hitAudio;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AddLight")
        {
            GameObject.Find("GameController").GetComponent<GameController>().MoreIntensityLight();
            gameObject.GetComponent<AudioSource>().clip = lightAudio;
            gameObject.GetComponent<AudioSource>().Play();

            Destroy(other.gameObject);
            particleGameObject = Instantiate(ligthParticles, gameObject.transform.position+ new Vector3(0f,0f,1f), ligthParticles.transform.rotation);
            particleGameObject.transform.SetParent(gameObject.transform);
        }
        if (other.tag == "LessLight")
        {
            GameObject.Find("GameController").GetComponent<GameController>().LessIntensityLight();
            gameObject.GetComponent<AudioSource>().clip = trashAudio;
            gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }
        if (other.tag == "AddVel")
        {
            mainCamera.GetComponent<CameraMovement>().SetVelocity();
            gameObject.GetComponent<AudioSource>().clip = velAudio;
            gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
            particleGameObject = Instantiate(velParticles, gameObject.transform.position + new Vector3(0f, 0f, 1f), velParticles.transform.rotation);
            particleGameObject.transform.SetParent(gameObject.transform);
        }
        if(other.tag == "Shark")
        {
            gameObject.GetComponent<AudioSource>().clip = sharkAudio;
            gameObject.GetComponent<AudioSource>().Play();
            SceneManager.LoadScene(2);
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
