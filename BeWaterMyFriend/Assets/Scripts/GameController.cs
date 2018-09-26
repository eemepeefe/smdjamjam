using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    private bool[,] positions;
    // Use this for initialization
    void Start() {
        fishScript = fish.GetComponent<FishMovement>();
        StartCoroutine(GenerateElements());
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
                Instantiate(nItems[Random.Range(0, nItems.Length)], generatedPosition, Random.rotation).transform.SetParent(parent.transform);
            }
            for (int i = 0; i < bonus; i++)
            {
                generatedPosition = GenerateRandomPosition();
                generatedPosition = new Vector3(leftSide.x + generatedPosition.x * sideOfset, yPosition, gameObject.transform.position.z + cameraOfsetPosition + generatedPosition.z * cameraOfsetZ);
                Instantiate(pItems[Random.Range(0, pItems.Length)], generatedPosition, Quaternion.Euler(0, -90, 0)).transform.SetParent(parent.transform);
            }
        }
    }
}
   
