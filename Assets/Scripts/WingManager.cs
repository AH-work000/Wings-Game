using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingManager : MonoBehaviour
{
    // Member variables for the main camera
    private GameObject mainCamera;

    private Camera mainCameraComponent;

    private float maxWidth;


    // Member variables for GameMode Selections
    public enum GameMode {Easy = 4, Medium = 2, Hard = 1};


    // Member variables for Animator of the Chicken Wing
    [SerializeField]
    private Animator wingAnimator;


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

        // Initialize the maxWidth --> Coordinate of the most right-hand
        // point (right edge) that the projectile goes up to
        maxWidth = mainCameraComponent.pixelWidth;
    }

    // Update is called once per frame
    void Update()
    {
        // Do the lerp where the game mode is set to easy (timeDuration = (Easy)4.0f)
        DoLerp((float)GameMode.Easy);

        // Check if the current pos of the wing is out of bounds
        if (IsWingsXPosOutOfBounds())
        {
            Destroy(gameObject);
        }
    }


    // Method: Do the lerp movement for the Chicken Wing
    private void DoLerp(float timeDuration)
    {
        // Create a new variable and make it get the current position of the Chicken Wing
        Vector3 oldPos = this.transform.position;

        // Create a new variable that stores the end position of the Chicken Wing
        Vector3 newPos = new Vector3(this.transform.position.x + 4.0f, this.transform.position.y); 

        // Divide the current time.deltaTime by timeDuration
        float timeFraction = Time.deltaTime / timeDuration;

        // Do the lerp method
        this.transform.position = Vector3.Lerp(oldPos, newPos, timeFraction);
    }


    // Method: Check if the wings x pos is out of bounds of the camera
    private bool IsWingsXPosOutOfBounds()
    {
        // Convert the World Coordinates of the Wings to Screen Coordinates
        Vector3 projectileScreenPos = mainCameraComponent.WorldToScreenPoint(this.transform.position);

        /* 
         * Return true if the x property of the wing screen pos is:
         * 
         * The x property of the wing screen pos is equal to or
         * greater than the (maximum width + 60.0f) of the camera
        */

        return projectileScreenPos.x >= maxWidth + 60.0f;

    }


    // PUBLIC METHODS



    // Method: Start the death animation of the chicken wing after it have been hit.
    public void startDeadAnim()
    {
        wingAnimator.SetTrigger("isDead");
    }

    // Method: Call the destoryWingPrefab Method of the Chicken Wing
    // that got shot by a projectile
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

}
