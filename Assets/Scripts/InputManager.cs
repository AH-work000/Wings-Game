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

    // Start is called before the first frame update
    void Start()
    {
        hotSauceSprayXPos = hotsauceSprayRenderer.transform.position.x;

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
            Debug.Log("Screen Position of the Hotsource Spray" + hotsauceScreenPos);


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

        // Get the horizontal axis where it moves 3.5 metres per second
        movement.x += Input.GetAxis("Horizontal") * 0.08f * Time.deltaTime;


        // Check if the current x pos of the Hotsource Spray Machine is outside
        // the width range of the Camera.
        if (CheckIfHotsauceSprayOutOfCamera(hotsauceSprayRenderer.transform))
        {
            // The move translation of the Hotsauce Spray Machine along the x axis
            hotsauceSprayRenderer.transform.Translate(movement, Space.World);
        }

    }

    // Method to Check if the current x pos of the Hotsource Spray Machine is outside
    // the width range of the Camera.
    private bool CheckIfHotsauceSprayOutOfCamera(Transform targetTransform)
    {
        // Convert the World Coordinates of the Hotsauce Spray Machine to Screen Coordinates
        hotsauceScreenPos = mainCamera.WorldToScreenPoint(targetTransform.position);

        // Designate the coordinate of the maximum point (right edge) that the Hotsauce Spray Machine stops at
        float xPosAtRightEdge = mainCamera.pixelWidth - 100f;

        // Designate the coordinate of the minimum point (left edge) that the Hotsauce Spray Machin stops at
        float xPosAtLeftEdge = 100f;


        if (hotsauceScreenPos.x <= xPosAtRightEdge && hotsauceScreenPos.x >= xPosAtLeftEdge)
        {
            return true;
        }

        return false;

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
