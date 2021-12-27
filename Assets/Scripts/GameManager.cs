using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

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


    // Member variables for GameMode Selections
    public enum GameMode { Easy = 4, Medium = 3, Hard = 2 };


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
    }



    // Update is called once per frame
    void Update()
    {
        // Check if the timer is over or equal to the interval provided by the GameMode
        // and less than three chicken wings have been missed
        if (timer >= (float)GameMode.Hard & !isTheGameOver)
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
            audioManagerScript.PlayGameplayMusic();
            isGameplayMusicOn = true;
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

            // Check if the Gameover scene is loaded
            if (!sceneLoaded)
            {
                // Pause the ability for the player to move the hot spray machine and shoot its projectile
                inputManagerScript.isItGameOver = true;

                // Load the Gameover Scene using Async Loading
                SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

                // Play the gameover music
                StartCoroutine(audioManagerScript.PlayGameOverMusic());

                // Make the sceneLoaded bool to be true so that only one copy of Gameover scene is loaded
                sceneLoaded = true;

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

}
