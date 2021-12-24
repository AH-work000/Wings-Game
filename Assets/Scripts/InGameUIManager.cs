using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    // Member Variables -- UI
    [SerializeField]
    private Text scoreText;

    // Member Variables -- Chicken Wing Life-Indicator Icons
    private GameObject chickenWing1GameObject;

    private GameObject chickenWing2GameObject;

    private GameObject chickenWing3GameObject;

    public Image chickenWingIcon1Image;

    public Image chickenWingIcon2Image;

    public Image chickenWingIcon3Image;


    // Member Variables -- Non-UI
    private int score;


    // Start is called before the first frame update
    void Start()
    {
        // Initialize the score float variable to 0
        score = 0;

        /* 
        // Initialize all member variables regarding Chicken Wing Icon 1
        chickenWing1GameObject = GameObject.FindGameObjectWithTag("Icon1");
        chickenWingIcon1Image = chickenWing1GameObject.GetComponent<Image>();


        // Initialize all member variables regarding Chicken Wing Icon 2
        chickenWing2GameObject = GameObject.FindGameObjectWithTag("Icon2");
        chickenWingIcon2Image = chickenWing2GameObject.GetComponent<Image>();

        // Initialize all member variables regarding Chicken Wing Icon 3
        chickenWing3GameObject = GameObject.FindGameObjectWithTag("Icon3");
        chickenWingIcon3Image = chickenWing3GameObject.GetComponent<Image>(); */

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

    // Method: Remove a chicken wing icon from the life-indicator bar when a non-sprayed chicken wing
    // successfully crosses the screen
    public void RemoveChickenWingIcon(char choice)
    {
        // Initialize the selection variable
        char selection = choice;

        switch (selection)
        {
            case 'A': Destroy(chickenWingIcon1Image); break;
            case 'B': Destroy(chickenWingIcon2Image); break;
            case 'C': Destroy(chickenWingIcon3Image); break;
        }
    }

}
