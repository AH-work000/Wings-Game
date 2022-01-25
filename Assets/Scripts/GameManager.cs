using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static GameModeDifficultyController;

public class GameManager : MonoBehaviour
{
    // Member Variables for the Scripts
    [SerializeField]
    public InputManager inputManagerScript;

    [SerializeField]
    public AudioManager audioManagerScript;

    [SerializeField]
    public WingManager wingManagerScript;

    [SerializeField]
    public InGameUIManager inGameUIScript;


    // Member Variables for Prefabs and GameObjects
    [SerializeField]
    private GameObject chickenWing;


    // Member Variables that concerns the Main Camera
    [SerializeField]
    private Camera mainCamera;

    private float maxHeight;

    private float maxWidth;

    private float footerHeight;

    private float inGameUIHeight;

    private float posSpacingLength;


    // Bool Member Variables
    private bool isGameplayMusicOn = false;

    private bool isTheGameOver = false;

    private bool sceneLoaded = false;


        // Bool Member Variables -- Life-Indicators
        private bool missedOneWing = false;

        private bool missedTwoWing = false;


    // Member Variables for Timer Function
    private float timer;


    // Member variable array for StartingYCoord Pos of the Chicken Wing Prefab
    private float[] startingYCoordArray = new float[] { 2.5f, 3.5f, 4.5f, 5.5f, 6.5f, 7.5f };

    // Member Variables for the Menu Manager
    private GameObject menuManager;

    private MenuManager menuManagerScript;


    // Member Property for storing the selected GameMode
    private GameMode selectedGameMode;


    // Member Variables for PlayerPrefs
    private const string saveHighScoreKey = "High Score";



    // Start is called before the first frame update
    void Start()
    {
        // Initialize the maxHeight -->  Coordinate of the highest point
        // (top edge) that the projectile goes up to
        maxHeight = mainCamera.pixelHeight;

        // Initialize the maxWidth --> Coordinate of the most right-hand
        // point (right edge) that the projectile goes up to
        maxWidth = mainCamera.pixelWidth;

        // Initialize the footerHeight variable --> The height of the
        // Hotsauce Spray section/area
        footerHeight = maxHeight / 5;

        // Initialize the inGameUIHeight variable --> The height of the
        // In-Game-UI bar area
        inGameUIHeight = maxWidth / 5;

        // Initialize the posSpacingLength variable --> The distance
        // between each starting position of the wings on the y-axis
        posSpacingLength = maxHeight / 10;

        // Load in the High Score into the High Score Text Field
        inGameUIScript.SetHighScore(PlayerPrefs.GetInt(saveHighScoreKey));

        // Locate a gameObject that have the tag "MenuManager"
        // and store it into the menuManager variable
        menuManager = GameObject.FindGameObjectWithTag("MenuManager");

        // Get the menuManagerScript component from the menuManager object
        menuManagerScript = menuManager.GetComponent<MenuManager>();

        // Get the stored value from the selectedGameMode variable in the
        // GameMode Difficulty Controller to the selectedGameMode in the GameManager
        selectedGameMode = GameModeDifficultyController.selectedGameMode;

        // Execute the selectGameMode method to choose the speed of Wing
        // based on the game difficulty
        SelectGameMode(selectedGameMode);
    }



    // Update is called once per frame
    void Update()
    {

        if (menuManagerScript.isTheCurrentScene("GamePlay") || menuManagerScript.isTheCurrentScene("GameOver"))
        {
            // Check if the timer is over or equal to the interval provided by the GameMode
            // and less than three chicken wings have been missed
            if (timer >= (float)selectedGameMode && !isTheGameOver)
            {
                // Generate the element position reference for the startingYCoordArray
                int yCoordArrayElementPosition = Random.Range(0, 6);

                // Instantiate the Chicken Wing as the following position
                CreateChickenWing(startingYCoordArray[yCoordArrayElementPosition]);

                // Once the chicken have been launch -- Call the ResetTimer Method
                ResetTimer();
            }


            // Timer -- Add the time.deltaTime of each frame to the timer member variable 
            timer += Time.deltaTime;


            // Check if the gameplay music is off at this moment
            if (!isGameplayMusicOn)
            {
                StartCoroutine(audioManagerScript.PlayGameplayMusic());
                isGameplayMusicOn = true;
            }

        }

    }



    // FUNCTIONS AND PROCEDURE


        // Method: Set the Y Coordinate of the Chicken Wing Starting Position
        private float SetYCoordStartingPos(float multiplier)
        {
            // Multiply the osSpacingLength by the designated multiplier to get the Y Coordinates of
            // Chicken Wing Starting Position in Screen Point
            float yScreenPos = posSpacingLength * multiplier;

            // Convert yScreenPos from Screen Point to World Space
            float yCoordStartingPos = GetYCoordInWorldSpace(yScreenPos);

            return yCoordStartingPos;
        }



        // Method: Create and launch a Chicken Wing Prefab
        private void CreateChickenWing(float yCoordPos)
        {
            Instantiate(chickenWing, new Vector3(GetXCoordInWorldSpace(-30), SetYCoordStartingPos(yCoordPos), 0), Quaternion.identity);
        }



        // Method: Check for how many icons are left in the life-indicators and
        // remove a chicken wing icon based on that
        public void RemoveChickenWingIcon()
        {
        // Check if the life-indicator has all three chicken wing icons
        if (!missedOneWing)
        {
            // Update the life-indicator to lose the first chicken wing icon
            inGameUIScript.RemoveChickenWingIcon('A');

            // Change the missedOneWing bool to true
            missedOneWing = true;
        }
        else if (!missedTwoWing)
        {
            // Update the life-indicator to lose the second chicken wing icon
            inGameUIScript.RemoveChickenWingIcon('B');

            // Change the missedTwoWing bool to true
            missedTwoWing = true;
        }
        else
        {
            // Update the life-indicator to lose the final chicken wing icon
            inGameUIScript.RemoveChickenWingIcon('C');

            // Make the isTheGameOver bool to be true as at least three wings have been missed
            // This stops the game from generating more chicken wings
            isTheGameOver = true;

            // Destroy all Chicken Wing Instances that is still currently in the scene
            DeleteAllChickenWings();

            // Check if the Gameover scene is not loaded yet
            if (!sceneLoaded)
            {
                // Pause the ability for the player to move the hot spray machine and shoot its projectile
                inputManagerScript.isItGameOver = true;

                // Load the Gameover Scene by calling the LoadGameOverScene method in the Load Manager
                menuManagerScript.LoadScene("GameOver");

                // Play the gameover music
                StartCoroutine(audioManagerScript.PlayGameOverMusic());

                // Make the sceneLoaded bool to be true so that only one copy of Gameover scene is loaded
                sceneLoaded = true;

                // Save high score data
                SaveHighScore();
            }

        }

    }



    // HELPER METHODS

        // Method: Convert X Coordinate Value from Screen Point to World Space
        private float GetXCoordInWorldSpace(float xCoord)
        {
            // Make the xCoord variable as the x float property for the newVector variable
            // It is as ScreenToWorldPoint method only accepts Vector3 as paramaters. 
            Vector3 newVector = mainCamera.ScreenToWorldPoint(new Vector3(xCoord, 0, 0));

            // Return just the y property as the X Coordinate of the Starting Position
            // of the wing in World Space
            return newVector.x;
        }



        // Method: Convert Y Coordinate Value from Screen Point to World Space
        private float GetYCoordInWorldSpace(float yCoord)
        {
            // Make the yCoord variable as the y float property for the newVector variable
            // It is as ScreenToWorldPoint method only accepts Vector3 as paramaters. 
            Vector3 newVector = mainCamera.ScreenToWorldPoint(new Vector3(0, yCoord, 0));

            // Return just the y property as the Y Coordinate of the Starting Position
            // of the wing in World Space -- Mathf.Abs is added to make the return value positive
            return newVector.y;
        }


        // Method: Reset the timer to zero
        private void ResetTimer()
        {
            timer = 0.0f;
        }


        // Method: Delete all instances of chicken wings in the scene
        private void DeleteAllChickenWings()
        {
            // Get all chicken wing objects currently still in the scene and store it into an array variable
            GameObject[] chickenWingArray = GameObject.FindGameObjectsWithTag("ChickenWing");

            // Foreach loop to delete all stored instances of chickenWings in the chickenWingArray
            foreach (GameObject chickenWing in chickenWingArray)
            {
                Destroy(chickenWing);
            }
        }



    // GAMEMODE METHODS

        // Method: Designate the GameMode chosen by the user and store it
        // into the selectedGameMode Variable
        public void SelectGameMode(GameMode gameMode)
        {
            // (if) When the gameMode equals Medium --> Make the timeMultplier to be 1.5f
            // (else if) When the gameMode equals Hard --> Make the timeMultplier to be 1.8f
            // (else) When the gameMode equals Easy (Default) --> Make the timeMultplier to be 1.0f
            if (gameMode == GameMode.Medium)
            {
                wingManagerScript.timeMultplier = 1.5f;
            }
            else if (gameMode == GameMode.Hard)
            {
                wingManagerScript.timeMultplier = 1.8f;
            }
            else
            {
                wingManagerScript.timeMultplier = 1.0f;
            }
        }


        // Method: Set the selectedGameMode Variable
        public void SetGameMode(GameMode gameMode)
        {
            selectedGameMode = gameMode;
        }


    // PLAYERPREFS METHODS

        // Method: Save the Player's High Score
        public void SaveHighScore()
        {
            // Get and store the high score value
            int highScore = inGameUIScript.GetHighScore();

            // Get and store the current high score value
            int currentHighScore = PlayerPrefs.GetInt(saveHighScoreKey);

            // Check if the high score value is greater than 
            // the current one stored in the PlayerPrefs
            if (highScore >= currentHighScore) //0 
        {
                // Create/Update Playerpref
                PlayerPrefs.SetInt(saveHighScoreKey, highScore);

                // Save
                PlayerPrefs.Save();
            }
        }

}
