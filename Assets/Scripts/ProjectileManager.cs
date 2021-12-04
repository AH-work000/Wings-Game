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

    private float maxHeightYPos;

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

        // Initialize the maxHeightYPos -->  Coordinate of the highest point
        // (top edge) that the projectile goes top
        maxHeightYPos = mainCameraComponent.pixelHeight;
    }

    // Update is called once per frame
    void Update()
    {
        DoLerp();

        // Check if the current height of the projectile is equal or over the
        // maximum height of the camera
        if (GetProjectileScreenYPos() >= maxHeightYPos)
        {
            DestoryObject();
        }
    }

    // Method: Get the Current Y Screen Position  of the Projectile
    private float GetProjectileScreenYPos()
    {
        // Convert the World Coordinates of the Projectile to Screen Coordinates
        Vector3 projectileScreenPos = mainCameraComponent.WorldToScreenPoint(this.transform.position);

        // Return the Y component of projectileScreenPos
        return projectileScreenPos.y;
    }


    // Method: Do the lerp movement for the projectile
    private void DoLerp()
    {
        // Create a new variable and make it get the current position of the Hotsauce Spray
        Vector3 oldPos = this.transform.position;

        // Create a new variable that stores the end position of the Hotsauce Spray
        Vector3 newPos = new Vector3(this.transform.position.x, this.transform.position.y + 1.0f);

        // Divide the current time.deltaTime by 2.0f (Time duration)
        float timeFraction = Time.deltaTime / TIME_DURATION;

        // Do the lerp method
        this.transform.position = Vector3.Lerp(oldPos, newPos, timeFraction);
    }


    // Method: Destroy this Object
    private void DestoryObject()
    {
        Destroy(gameObject);
        Debug.Log("Object has been destoryed");
    }

}
