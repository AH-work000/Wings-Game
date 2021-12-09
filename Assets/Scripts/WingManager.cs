using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingManager : MonoBehaviour
{
    // Member variables for the main camera
    private GameObject mainCamera;

    private Camera mainCameraComponent;

    private float maxHeightYPos;

    private float maxWidthXPos;

    private float footerHeight;

    private float inGameUIHeight;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the mainCamera GameObject by using the FindGameObjectWithTag method
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        // Initialize the mainCameraComponent by 
        mainCameraComponent = mainCamera.GetComponent<Camera>();

        // Initialize the maxHeightYPos -->  Coordinate of the highest point
        // (top edge) that the projectile goes up to
        maxHeightYPos = mainCameraComponent.pixelHeight;

        // Initialize the maxWidthXPos --> Coordinate of the most right-hand
        // point (right edge) that the projectile goes up to
        maxWidthXPos = mainCameraComponent.pixelWidth;

        // Initialize the footerHeight variable --> The height of the
        // Hotsauce Spray section/area
        footerHeight = mainCameraComponent.pixelHeight / 5;
   
        // Initialize the inGameUIHeight variable --> The height of the
        // In-Game-UI bar area
        inGameUIHeight = mainCameraComponent.pixelHeight / 5;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Footer Height: " + footerHeight);
        Debug.Log("In-Game-UI Height: " + inGameUIHeight);
    }


}
