using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static float score;       


    Text text;                      


    void Awake()
    {
        // Set up the reference.
        text = GetComponent<Text>();

        
    }

    private void Start()
    {
        // Reset the score.
        score = 0;
    }

    void Update()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        score = Time.timeSinceLevelLoad; ;
        text.text = "Score: " + (int)score +" s";
    }
}
