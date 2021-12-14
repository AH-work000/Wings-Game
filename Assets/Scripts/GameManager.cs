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



    // Temp Member Variables -- ONLY FOR TESTING; TO BE DELETED LATER
    private bool hasAllWingsSpawn = false;



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


        // Instantiate the Chicken Wings as the following position -- TO BE EDITED LATER
        if (!hasAllWingsSpawn)
        {
            Instantiate(chickenWing, new Vector3(GetXCoordInWorldSpace(-30), SetYCoordStartingPos(2.5f), 0), Quaternion.identity);
            Instantiate(chickenWing, new Vector3(GetXCoordInWorldSpace(-30), SetYCoordStartingPos(3.5f), 0), Quaternion.identity);
            Instantiate(chickenWing, new Vector3(GetXCoordInWorldSpace(-30), SetYCoordStartingPos(4.5f), 0), Quaternion.identity);
            Instantiate(chickenWing, new Vector3(GetXCoordInWorldSpace(-30), SetYCoordStartingPos(5.5f), 0), Quaternion.identity);
            Instantiate(chickenWing, new Vector3(GetXCoordInWorldSpace(-30), SetYCoordStartingPos(6.5f), 0), Quaternion.identity);
            Instantiate(chickenWing, new Vector3(GetXCoordInWorldSpace(-30), SetYCoordStartingPos(7.5f), 0), Quaternion.identity);
            hasAllWingsSpawn = true;
        }
        
    }

    // FUNCTIONS AND PROCEDURE


        // Method: Set the Y Coordinate of the Chicken Wing Starting Position
        private float SetYCoordStartingPos(float multiplier)
        {
            // Multiply the osSpacingLength by the designated multiplier to get the Y Coordinates of
            // Chicken Wing Starting Position in Screen Point
            float yScreenPos = posSpacingLength * multiplier;

            Debug.Log("The Y Coordinate of the Starting Position (Screen Point) is: " + yScreenPos);

            // Convert yScreenPos from Screen Point to World Space
            float yCoordStartingPos = GetYCoordInWorldSpace(yScreenPos);


            Debug.Log("The Y Coordinate of the Starting Position is: " + yCoordStartingPos);


            return yCoordStartingPos;
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

}
