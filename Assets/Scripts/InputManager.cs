using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Member Variables

    [SerializeField]
    private SpriteRenderer hotsauceSprayRenderer;

    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private GameManager gameManager;



    // Member Variables for all variation of the Hotsauce Spray Sprite

    [SerializeField]
    private Sprite hotSauceSprayLeftPos;

    [SerializeField]
    private Sprite hotSauceSprayUpPos;

    [SerializeField]
    private Sprite hotSauceSprayRightPos;



    // Member Variables Prefabs
    [SerializeField]
    private GameObject hotSauceProjectileUpFacing;

    [SerializeField]
    private GameObject hotSauceProjectileRightFacing;

    [SerializeField]
    private GameObject hotSauceProjectileLeftFacing;



    // Member Variables for Hotsauce Spray Machine
    private Vector3 movement;

    private Vector3 hotsauceScreenPos;

    private float minDistanceXPos;

    private float maxDistanceXPos;



    // Member Variables for Timer Function
    private float timer;



    // Boolean Member Variables for checking what rotation pos is the Hotsauce Spray at
    private bool hasRightFacingPos;

    private bool hasUpFacingPos;

    private bool hasLeftFacingPos;



    // Start is called before the first frame update
    void Start()
    {

        // Initialize minDistanceXPos --> Designate the coordinate of the minimum point
        // (left edge) that the Hotsauce Spray Machin stops at
        minDistanceXPos = mainCamera.pixelWidth / 15; 

        // Initialize the maxDistanceXPos -->  Coordinate of the maximum point
        // (right edge) that the Hotsauce Spray Machine stops at
        maxDistanceXPos = mainCamera.pixelWidth - minDistanceXPos;

        // Initialize the timer variable to be at 0.0f
        timer = 0.0f;

        // Initialize all bool variables (hasUpFacingPos to true as it is the default position)
        hasRightFacingPos = false;
        hasUpFacingPos = true;
        hasLeftFacingPos = false;
    }


    // Update is called once per frame
    void Update()
    {
        // Timer

            // Check if the value of the timer is less than 0.5f 
            if (timer < 0.5f)
            {
                // Count the time by adding time.deltaTime to the timer variable for each frame
                timer += Time.deltaTime;
                Debug.Log(timer);
            }


        // Input to shoot the projectile

             
            // If the 'X' Key is pressed and the timer is over 0.5 seconds in value
            // --> Launch a Hotsauce Capsule Projectile
            if (Input.GetKeyDown(KeyCode.X) && IsTimerOverHalfASecond())
            {
                // Do the LaunchProjectile Method
                LaunchProjectile();

                // Play the sound that comes with launching the projectile
                gameManager.audioManagerScript.PlayShootSound();

                // Reset the timer to 0.0f;
                timer = 0.0f;
            }
  

        // Inputs for the rotation of the Hotsauce Spray Machine

            // If the 'E' Key is pressed --> Rotate the Hotsauce Spray Machine 45 degrees (RightPos)
            if (Input.GetKeyDown(KeyCode.E))
            {
                hotsauceSprayRenderer.sprite = hotSauceSprayRightPos;

                // Make the hasRightFacingPos bool to be true
                hasRightFacingPos = true;
                hasUpFacingPos = false;
                hasLeftFacingPos = false;
            }

            // If the 'Q' Key is pressed --> Rotate the Hotsauce Spray Machine -45 degree (LeftPos)
            if (Input.GetKeyDown(KeyCode.Q))
            {
                hotsauceSprayRenderer.sprite = hotSauceSprayLeftPos;

                // Make the hasLeftFacingPos bool to be true
                hasRightFacingPos = false;
                hasUpFacingPos = false;
                hasLeftFacingPos = true;
            }

            // If the 'W' Key is pressed --> Rotate the Hotsauce Spray Machine back to its Up Pos
            if (Input.GetKeyDown(KeyCode.W))
            {
                hotsauceSprayRenderer.sprite = hotSauceSprayUpPos;

                // Make the hasUpFacingZPos bool to be true
                hasRightFacingPos = false;
                hasUpFacingPos = true;
                hasLeftFacingPos = false;
            }



        // Hotsauce Spray Movement

            // Get the horizontal axis where it moves 0.05 metres per second
            movement.x += Input.GetAxisRaw("Horizontal") * 0.05f * Time.deltaTime;


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
                    hotsauceSprayRenderer.transform.position = new Vector3(ConvertScreenXPosToWorld(minDistanceXPos), hotsauceSprayRenderer.transform.position.y);
                }
            
            }

    }

    // Method: Check if the current x pos of the Hotsource Spray Machine is outside
    // the width range of the Camera.
    private bool CheckIfHotsauceSprayOutOfCamera(Transform targetTransform)
    {
        // Convert the World Coordinates of the Hotsauce Spray Machine to Screen Coordinates
        hotsauceScreenPos = mainCamera.WorldToScreenPoint(targetTransform.position);

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


    // Method: Create a new capsule projectile and launch it
    private void LaunchProjectile()
    {
        // If hasUpFacingPos bool is true --> generate a projectile that is going north in direction
        if (hasUpFacingPos)
        {
            Instantiate(hotSauceProjectileUpFacing, new Vector3(hotsauceSprayRenderer.transform.position.x + 0.03f, -5.80f, 0f), Quaternion.identity);
        }


        // If hasRightFacingPos bool is true --> generate a projectile that is going north-east in direction (orientation)
        if (hasRightFacingPos)
        {
            Instantiate(hotSauceProjectileRightFacing, new Vector3(hotsauceSprayRenderer.transform.position.x + 0.84f, -6.11f, 0f), Quaternion.identity);
        }


        // If hasLeftFacingPos bool is true --> generate a prokectile that is going north-west in direction (orientation)
        if (hasLeftFacingPos)
        {
            Instantiate(hotSauceProjectileLeftFacing, new Vector3(hotsauceSprayRenderer.transform.position.x - 0.852f, -6.11f, 0f), Quaternion.identity);
        }

    }


    // Method: Check return the timer is over or at least 0.5 seconds in value
    private bool IsTimerOverHalfASecond()
    {
        return timer >= 0.5f;
    }

}
