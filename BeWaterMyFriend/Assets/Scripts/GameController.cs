using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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


    private bool[,] positions;
    // Use this for initialization
    void Start() {
        fishScript = fish.GetComponent<FishMovement>();
        StartCoroutine(GenerateElements());
        spotLight = GameObject.Find("Spot Light");
        intensityLight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            fishScript.SetFishLeftPosition();
        }
        if (Input.GetKey(KeyCode.D))
        {
            fishScript.SetFishRightPosition();
        }
        leftLightLimit = spotLight.transform.position.x - ofsetLight;
        rightLightLimit = spotLight.transform.position.x + ofsetLight;

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
                item = Instantiate(nItems[Random.Range(0, nItems.Length)], generatedPosition, Quaternion.Euler(-90, 0, 0));
                item.transform.SetParent(parent.transform);
            }
            for (int i = 0; i < bonus; i++)
            {
                generatedPosition = GenerateRandomPosition();
                generatedPosition = new Vector3(leftSide.x + generatedPosition.x * sideOfset, yPosition, gameObject.transform.position.z + cameraOfsetPosition + generatedPosition.z * cameraOfsetZ);
                item = Instantiate(pItems[Random.Range(0, pItems.Length)], generatedPosition, Quaternion.Euler(0, -90, 0));
                item.transform.SetParent(parent.transform);
            }
        }
    }

    public void LessIntensityLight()
    {
        intensityLight += 1;
        healthSlider.value -= 25;
    }

    public void MoreIntensityLight()
    {
        intensityLight -= 1;
        healthSlider.value += 25;
    }
}
   
