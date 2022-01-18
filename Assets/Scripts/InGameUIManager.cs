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

    [SerializeField]
    private Text highScoreText;

    // Member Variables -- Chicken Wing Life-Indicator Icons
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


        // Method: Set the High Score text to the one saved in the PlayerPrefs
        public void SetHighScore(int highScore)
        {
            highScoreText.text = "" + highScore;
        }


        // Method: Get the High Score from the High Score Text Field
        public int GetHighScore()
        {
            int highScore = int.Parse(scoreText.text);
            return highScore;
        }

}
