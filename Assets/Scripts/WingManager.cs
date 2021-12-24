using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingManager : MonoBehaviour
{
    // Member variables for the main camera
    private GameObject mainCamera;

    private Camera mainCameraComponent;

    private float maxWidth;


    // Member variables for the Animator of the Chicken Wing
    [SerializeField]
    private Animator wingAnimator;


    // Member variables for the Game Manager 
    private GameObject gameManagerObject;

    private GameManager gameManager;


    // Bool Member Variables
    private bool hasHit;

    private bool soundIsOn;

    private bool isPointAdded;



    void Awake()
    {
        // Initialize the mainCamera GameObject by using the FindGameObjectWithTag static method
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        // Initialize the gameManagerObject GameObject by using the FindGameObjectWithTag static method
        gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the mainCameraComponent by using the GetComponent static method
        mainCameraComponent = mainCamera.GetComponent<Camera>();

        // Initialize the gameManager by using the GetComponent static method
        gameManager = gameManagerObject.GetComponent<GameManager>();

        // Initialize the maxWidth --> Coordinate of the most right-hand
        // point (right edge) that the projectile goes up to
        maxWidth = mainCameraComponent.pixelWidth;

        // Initialize the hasHit bool variable as false
        // It's since the chicken wing prefab had not been hit
        hasHit = false;

        // Initialize the soundIsOn bool variable as false
        // It's since the chicken wing prefab had not been hit
        soundIsOn = false;

        // Initialize the isPointAdded bool variable as false
        // It's since the chicken wing prefab had not been hit
        isPointAdded = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Do the lerp movement movement unless the chicken wing have been hit
        if (!hasHit)
        {
            // Do the lerp where the game mode is set to easy (timeDuration = (Easy)4.0f)
            DoLerp((float)GameManager.GameMode.Easy);
        }

        // Check if the current pos of the wing is out of bounds
        if (IsWingsXPosOutOfBounds())
        {
            // Destroy the wing using the WingDestroy() method
            WingDestroy();

            // If this is the 1st - 3rd chicken wing that have missed being shot,
            // remove a life (icon) from the life-indicator 
            gameManager.RemoveChickenWingIcon();
        }


        // Check if a chicken wing have been hit by checking if the hasHit bool is true
        if (hasHit)
        {

            // Check if the soundIsOn bool is set to false 
            if (!soundIsOn)
            {
                // Play the hit sound
                gameManager.audioManagerScript.PlayHitSound();

                // Set the soundIsOn bool to true as the sound is being played
                soundIsOn = true;
            }

            
           // Check if +10 point have been added to the score
           if (!isPointAdded)
            {
                // Add +10 to the score text
                gameManager.inGameUIScript.AddPoints();

                isPointAdded = true;
            }
           

            // Play the death animation 
            StartDeadAnim();


            // Destroy the Wing Prefab
            // (i.e. after the death animation is finished playing)
            Invoke("WingDestroy", 1.8f);

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
         * greater than the (maximum width + 32.0f) of the camera
        */

        return projectileScreenPos.x >= maxWidth + 45.0f;

    }



    // Method: Change the hasHit bool of the Chicken Wing to true
    // It happens when the chicken wing have been hit by a projectile
    private void OnTriggerEnter(Collider other)
    {
        // Set the hasHit boolean to true
        hasHit = true;
    }


    // Method: Destroy the Chicken Wing Prefab
    private void WingDestroy()
    {
        Destroy(gameObject);
    }


    // Method: Start the death animation of the chicken wing after it have been hit.
    private void StartDeadAnim()
    {
        wingAnimator.SetTrigger("isDead");
    }

}
