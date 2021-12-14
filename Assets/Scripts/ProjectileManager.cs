using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    // Member variables for the hot-sauce capsule projectile
    private const float TIME_DURATION = 0.2f;

    // Member variables for the main camera
    private GameObject mainCamera;

    private Camera mainCameraComponent;

    private float maxHeight;

    private float maxWidth;


    // Member variables for the direction of the lerping
    [SerializeField]
    private float xPosLerp;

    [SerializeField]
    private float yPosLerp;

    
    void Awake()
    {
        // Initialize the mainCamera GameObject by using the FindGameObjectWithTag method
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }


    // Start is called before the first frame update
    void Start()
    {
        // Initialize the mainCameraComponent by 
        mainCameraComponent = mainCamera.GetComponent<Camera>();

        // Initialize the maxHeight -->  Coordinate of the highest point
        // (top edge) that the projectile goes up to
        maxHeight = mainCameraComponent.pixelHeight;

        // Initialize the maxWidth --> Coordinate of the most right-hand
        // point (right edge) that the projectile goes up to
        maxWidth = mainCameraComponent.pixelWidth;
    }

    // Update is called once per frame
    void Update()
    {
        DoLerp();

        // Check if the current pos of the projectile is out of bounds
        if (IsProjectileOverMaxScreenHeight() || IsProjectileXPosOutOfBounds())
        {
            DestoryObject();
        }
    }

    // Method: Check if the projectile y pos is above the max height of the screen
    private bool IsProjectileOverMaxScreenHeight()
    {
        // Convert the World Coordinates of the Projectile to Screen Coordinates
        Vector3 projectileScreenPos = mainCameraComponent.WorldToScreenPoint(this.transform.position);

        // Return true if the y property of the projectile screen pos is equal to
        // or greater than the maximum height of the camera
        return projectileScreenPos.y >= maxHeight;
    }


    // Method: Check if the projectile x pos is out of bounds of the camera
    private bool IsProjectileXPosOutOfBounds()
    {
        // Convert the World Coordinates of the Projectile to Screen Coordinates
        Vector3 projectileScreenPos = mainCameraComponent.WorldToScreenPoint(this.transform.position);

        /* 
         * Return true if the x property of the projectile screen pos is:
         * 
         * The x property of the projectile screen pos is equal to or
         * greater than the maximum width of the camera
         * 
         * OR its screen position is negative
         * 
        */

        return projectileScreenPos.x >= maxWidth || projectileScreenPos.x <= 0;

    }


    // Method: Do the lerp movement for the projectile
    private void DoLerp()
    {
        // Create a new variable and make it get the current position of the Projectile
        Vector3 oldPos = this.transform.position;

        // Create a new variable that stores the end position of the Projectile
        Vector3 newPos = new Vector3(this.transform.position.x + xPosLerp, this.transform.position.y + yPosLerp); // + 1.0f; 

        // Divide the current time.deltaTime by 0.2f (Time duration)
        float timeFraction = Time.deltaTime / TIME_DURATION;

        // Do the lerp method
        this.transform.position = Vector3.Lerp(oldPos, newPos, timeFraction);
    }



    // Method: Destroy this Object -- TO BE DELETED AND MERGE 
    private void DestoryObject()
    {
        Destroy(gameObject);
    }

}
