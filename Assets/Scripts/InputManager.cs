using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Member Variables
    public SpriteRenderer hotSauceSprayRenderer;

    // Member Variables for all variation of the Hotsauce Spray

    [SerializeField]
    private Sprite hotSauceSprayLeft;

    [SerializeField]
    private Sprite hotSauceSprayUp;

    [SerializeField]
    private Sprite hotSauceSprayRight;


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


    }
}
