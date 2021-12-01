using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Member Variables

    public SpriteRenderer hotsauceSprayRenderer;

    public Camera mainCamera;

    // Member Variables for all variation of the Hotsauce Spray Sprite

    [SerializeField]
    private Sprite hotSauceSprayLeftPos;

    [SerializeField]
    private Sprite hotSauceSprayUpPos;

    [SerializeField]
    private Sprite hotSauceSprayRightPos;

    // Member Variables for Hotsauce Spray Machine
    private Vector3 movement;

    private float hotSauceSprayXPos;

    private Vector3 hotsauceScreenPos;


    // CONST Member Variables
    private float maxDistanceXPos;  

    // Start is called before the first frame update
    void Start()
    {
        hotSauceSprayXPos = hotsauceSprayRenderer.transform.position.x;

        // Initialize the maxDistanceXpos -->  Coordinate of the maximum point
        // (right edge) that the Hotsauce Spray Machine stops at
        maxDistanceXPos = mainCamera.pixelWidth - 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug Section

        // Print out the Time for each frame -- To be commented out once the game is completed
        // Debug.Log("Time DeltaTime: " + Time.deltaTime);

        // Print out the Time for the duration of the game -- To be commented out once the game is completed
        // Debug.Log("Time since start game: " + Time.time);

        // Print out properties info regarding the Main Camera
        // Debug.Log("Screen Position of the Hotsource Spray" + hotsauceScreenPos);


        // Code Section 


        // Inputs for the rotation of the Hotsauce Spray Machine

            // If the 'E' Key is pressed --> Rotate the Hotsauce Spray Machine 45 degrees (RightPos)
            if (Input.GetKeyDown(KeyCode.E))
            {
                hotsauceSprayRenderer.sprite = hotSauceSprayRightPos;
            }

            // If the 'Q' Key is pressed --> Rotate the Hotsauce Spray Machine -45 degree (LeftPos)
            if (Input.GetKeyDown(KeyCode.Q))
            {
                hotsauceSprayRenderer.sprite = hotSauceSprayLeftPos;
            }

            // If the 'W' Key is pressed --> Rotate the Hotsauce Spray Machine back to its Up Pos
            if (Input.GetKeyDown(KeyCode.W))
            {
                hotsauceSprayRenderer.sprite = hotSauceSprayUpPos;
            }

        // Get the horizontal axis where it moves 0.08 metres per second
        movement.x += Input.GetAxisRaw("Horizontal") * 0.08f * Time.deltaTime;

        // The move translation of the Hotsauce Spray Machine along the x axis
        hotsauceSprayRenderer.transform.Translate(movement, Space.World);


        // Check if the current x pos of the Hotsource Spray Machine is outside
        // the width range of the Camera.
        if (CheckIfHotsauceSprayOutOfCamera(hotsauceSprayRenderer.transform))
        {
            // The move translation of the Hotsauce Spray Machine along the x axis
            hotsauceSprayRenderer.transform.Translate(movement, Space.World);
        }
        else
        {
            // Check whether the Hotsauce Spray Machine is located on the left or right of its range movement limit
            if (hotsauceSprayRenderer.transform.position.x >= ConvertScreenXPosToWorld(maxDistanceXPos))
            {
                hotsauceSprayRenderer.transform.position = new Vector3(ConvertScreenXPosToWorld(maxDistanceXPos), hotsauceSprayRenderer.transform.position.y);
            } else
            {
                hotsauceSprayRenderer.transform.position = new Vector3(ConvertScreenXPosToWorld(100.0f), hotsauceSprayRenderer.transform.position.y);
            }
            
        }

    }

    // Method: Check if the current x pos of the Hotsource Spray Machine is outside
    // the width range of the Camera.
    private bool CheckIfHotsauceSprayOutOfCamera(Transform targetTransform)
    {
        // Convert the World Coordinates of the Hotsauce Spray Machine to Screen Coordinates
        hotsauceScreenPos = mainCamera.WorldToScreenPoint(targetTransform.position);

        // Designate the coordinate of the minimum point (left edge) that the Hotsauce Spray Machin stops at
        float minDistanceXPos = 100.0f;

        // Return true when the current pos of the Hotsauce Spray is less than the x Pos of the Right Edge minus 100px
        // and greater than the x Pos of the Left Edge of the Camera plus 100px. 
        if (hotsauceScreenPos.x <= maxDistanceXPos && hotsauceScreenPos.x >= minDistanceXPos)
        {
            return true;
        }

        // Otherwise return false
        return false;
    }



    // Method: Convert the x property of the Screen Position to World 
    private float ConvertScreenXPosToWorld(float xPos)
    {
        Vector3 convertedXPos = mainCamera.ScreenToWorldPoint(new Vector3(xPos, 0));
        return convertedXPos.x;
    }

    /* 
    // Method for doing the lerp movement
    private void DoLerp()
    {
        // Create a new variable and make it get the current position of the Hotsauce Spray
        Vector3 oldPos = hotSauceSprayRenderer.transform.position;

        // Create a new variable that stores the end position of the Hotsauce Spray
        Vector3 newPos = new Vector3(hotSauceSprayRenderer.transform.position.x - 1.0f, hotSauceSprayRenderer.transform.position.y);

        // Divide the current time.deltaTime by 2.0f (Time duration)
        float timeFraction = Time.deltaTime / TIME_DURATION;

        // Do the lerp method
        hotSauceSprayRenderer.transform.position = Vector3.Lerp(oldPos, newPos, timeFraction);
    } */

}
