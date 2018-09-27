using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialEmissionFish : MonoBehaviour {
    Material mat;
    public Texture emissive;
    private GameObject mainCharacter;
    public float leftLimit;
    public float rightLimit;
    private string name;
    public float timeDestroy;
    public int intensityLight;
    private GameController gameController;
    // Use this for initialization
    void Start()
    {
        name = gameObject.transform.parent.gameObject.name.Replace("(Clone)", "");
        

        timeDestroy = 5;
        StartCoroutine(DestroyGamObject());
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        intensityLight = gameController.intensityLight;

    }

    // Update is called once per frame
    void Update () {
        intensityLight = gameController.intensityLight;
        if (gameObject.transform.position.x > gameController.leftLightLimit && gameObject.transform.position.x < gameController.rightLightLimit)
        {
            SetLight();
        }
        else
        {
            SetNoLight();
        }
    }
    IEnumerator DestroyGamObject()
    {
        yield return new WaitForSeconds(timeDestroy);
        Destroy(gameObject.transform.parent.gameObject);
    }

    private void SetLight()
    {
        emissive = Resources.Load<Texture>(name + "_" + intensityLight);
        mat = GetComponent<Renderer>().material;
        mat.EnableKeyword("_EMISSION");
        mat.SetTexture("_EmissionMap", emissive);
        mat.SetColor("_EmissionColor", Color.white);
        mainCharacter = GameObject.Find("spot_light");
    }

    private void SetNoLight()
    {
        mat = GetComponent<Renderer>().material;
        mat.DisableKeyword("_EMISSION");
    }

    public void LessIntensityLight()
    {
        intensityLight += 1;
    }

    public void MoreIntensityLight()
    {
        intensityLight -= 1;
    }
}
