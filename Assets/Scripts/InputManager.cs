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

    // Member Variables for Hotsauce Spray Machine
    private Vector3 movement;

    private Vector3 hotsauceScreenPos;

    private float maxDistanceXPos;


    // Member Variables Prefabs
    [SerializeField]
    private GameObject hotSauceProjectile;


    // Start is called before the first frame update
    void Start()
    {
        // Initialize the maxDistanceXPos -->  Coordinate of the maximum point
        // (right edge) that the Hotsauce Spray Machine stops at
        maxDistanceXPos = mainCamera.pixelWidth - 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
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

            // If the 'X' Key is pressed --> Launch a Hotsauce Capsule Projectile
            if (Input.GetKeyDown(KeyCode.X))
            {
                // Do the LaunchProjectile Method
                LaunchProjectile();

                // Play the sound that comes with launching the projectile
                gameManager.audioManagerScript.PlayShootSound(); 
            }

        // Get the horizontal axis where it moves 0.03 metres per second
        movement.x += Input.GetAxisRaw("Horizontal") * 0.03f * Time.deltaTime;

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


    // Method: Create a new capsule projectile and launch it
    private void LaunchProjectile()
    {
        Instantiate(hotSauceProjectile, new Vector3(hotsauceSprayRenderer.transform.position.x, -5.8f, 0f), Quaternion.identity);
    }

}
