using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Member Variables for the Scripts
    [SerializeField]
    public InputManager inputManagerScript;

    [SerializeField]
    public AudioManager audioManagerScript;

    [SerializeField]
    public WingManager wingManagerScript;



    // Member Variables for Prefabs

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
        // Print out the following stats to the console
            Debug.Log("Footer Height: " + footerHeight);
            Debug.Log("In-Game-UI Height: " + inGameUIHeight);

        // Get the yCoord rate and store it into a variable
        float yCoordRate = GetYCoordInWorldSpace(posSpacingLength); // Returns negative value

        Debug.Log("Y Coordinate Rate: " + yCoordRate);

        // Instantiate the Chicken Wings as the following position -- TO BE EDITED LATER
        Instantiate(chickenWing, new Vector3(GetXCoordInWorldSpace(-30), SetYCoordStartingPos(yCoordRate, 1.5f), 0), Quaternion.identity);

    }


    // Method: Set the Y Coordinate of the Chicken Wing Starting Position
    private float SetYCoordStartingPos(float yCoordRate, float multiplier)
    {
        // Multiply the designated Y Coordinate Rate by a whole number (multiplier) 
        return yCoordRate * multiplier;
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
            return Mathf.Abs(newVector.y);
        }

}
