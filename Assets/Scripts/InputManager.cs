using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Member Variables
    public SpriteRenderer hotSauceSprayRenderer;

    // Member Variables for all variation of the Hotsauce Spray

    [SerializeField]
    private Sprite hotSauceSprayLeftPos;

    [SerializeField]
    private Sprite hotSauceSprayUpPos;

    [SerializeField]
    private Sprite hotSauceSprayRightPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Print out the Time for each frame -- To be commented out once the game is completed
        Debug.Log("Time DeltaTime: " + Time.deltaTime);

        // Print out the Time for the duration of the game -- To be commented out once the game is completed
        Debug.Log("Time since start game: " + Time.time);

        // Inputs for the rotation of the Hotsauce Spray Machine


        // If the 'E' Key is pressed --> Rotate the Hotsauce Spray Machine 45 degrees (RightPos)
        if (Input.GetKeyDown(KeyCode.E))
        {
            hotSauceSprayRenderer.sprite = hotSauceSprayRightPos;
        }

        // If the 'Q' Key is pressed --> Rotate the Hotsauce Spray Machine -45 degree (LeftPos)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            hotSauceSprayRenderer.sprite = hotSauceSprayLeftPos;
        }

        // If the 'W' Key is pressed --> Rotate the Hotsauce Spray Machine back to its Up Pos
        if (Input.GetKeyDown(KeyCode.W))
        {
            hotSauceSprayRenderer.sprite = hotSauceSprayUpPos;
        }

    }
}
