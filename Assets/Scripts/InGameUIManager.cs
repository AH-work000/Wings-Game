using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    // Member Variables -- UI
    [SerializeField]
    private Text scoreText;

    // Member Variables -- Non-UI
    private int score;






    // Start is called before the first frame update
    void Start()
    {
        // Initialize the score float variable to 0
        score = 0;

        
    }


    // Update is called once per frame
    void Update()
    {
        scoreText.text = "" + score;
    }


    // PUBLIC METHODS


    // Method: Add +10 to the score variable when a chicken wing prefab have been hit
    public void AddPoints()
    {
        score += 10;
    }


}
