using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public GameObject fish;
    public GameObject cameraGame;
    public GameObject[] pItems;
    public GameObject[] nItems;
    FishMovement fishScript;
    public int dificulty;
    public int bonus;
    private Vector3 generatedPosition;
    public float yPosition;
    public Vector3 leftSide;
    public float cameraOfsetZ;
    public float cameraOfsetPosition;
    public float sideOfset;
    public float timeToGenerrate;
    public GameObject parent;
    private GameObject item;
    public int intensityLight;
    public float leftLightLimit;
    public float rightLightLimit;
    public float ofsetLight;
    public Slider healthSlider;
    private GameObject spotLight;
    int random;
    public GameObject bubbles;
    private GameObject bubbleInstance;

    private bool[,] positions;
    // Use this for initialization
    void Start() {
        fishScript = fish.GetComponent<FishMovement>();
        StartCoroutine(GenerateElements());
        StartCoroutine(GeneratePositiveElements());
        spotLight = GameObject.Find("Spot Light");
        intensityLight = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            fishScript.GetComponent<Animator>().SetBool("TurnLeft",true);
            fishScript.SetFishLeftPosition();
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            fishScript.GetComponent<Animator>().SetBool("TurnLeft", false);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            fishScript.GetComponent<Animator>().SetBool("TurnRight", true);
            fishScript.SetFishRightPosition();
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            fishScript.GetComponent<Animator>().SetBool("TurnRight", false);
        }
        else if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        leftLightLimit = spotLight.transform.position.x - ofsetLight;
        rightLightLimit = spotLight.transform.position.x + ofsetLight;
        if(intensityLight > 3)
        {
            SceneManager.LoadScene(2);
        }
    }

    Vector3 GenerateRandomPosition()
    {
        int x;
        int z;
        do
        {
            x = Random.Range(0, 9);
            z = Random.Range(0, 9);
        } while (positions[x, z] == true);

        positions[x, z] = true;
        return new Vector3(x, yPosition, z);


    }

    IEnumerator GenerateElements()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToGenerrate);
            positions = new bool[9, 9];

            for (int i = 0; i < dificulty; i++)
            {
                generatedPosition = GenerateRandomPosition();
                generatedPosition = new Vector3(leftSide.x + generatedPosition.x * sideOfset, yPosition, gameObject.transform.position.z + cameraOfsetPosition + generatedPosition.z * cameraOfsetZ);
                random = Random.Range(0, nItems.Length);
                item = Instantiate(nItems[random], generatedPosition, nItems[random].transform.rotation);
                item.transform.SetParent(parent.transform);
                bubbleInstance = Instantiate(bubbles, generatedPosition, bubbles.transform.rotation);
                bubbleInstance.transform.SetParent(item.transform);


            }
        }
    }

    IEnumerator GeneratePositiveElements()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToGenerrate * 10);
            positions = new bool[9, 9];
            
            for (int i = 0; i < bonus; i++)
            {
                generatedPosition = GenerateRandomPosition();
                generatedPosition = new Vector3(leftSide.x + generatedPosition.x * sideOfset, yPosition, gameObject.transform.position.z + cameraOfsetPosition + generatedPosition.z * cameraOfsetZ);
                random = Random.Range(0, pItems.Length);
                item = Instantiate(pItems[random], generatedPosition, pItems[random].transform.rotation);
                item.transform.SetParent(parent.transform);
            }
        }
    }

    public void LessIntensityLight()
    {
        intensityLight += 1;
        healthSlider.value -= 25;
        GameObject.Find("Halo").GetComponent<Light>().intensity /= 1.2f;
        GameObject.Find("Spot Light").GetComponent<Light>().range /= 1.2f;
    }

    public void MoreIntensityLight()
    {
        if (intensityLight > 0)
        {
            intensityLight -= 1;
            healthSlider.value += 25;
            GameObject.Find("Halo").GetComponent<Light>().intensity *= 1.2f;
            GameObject.Find("Spot Light").GetComponent<Light>().range *= 1.2f;
        }
    }
}
   
