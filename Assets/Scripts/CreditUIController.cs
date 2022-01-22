using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditUIController : MonoBehaviour
{
    // Member Variables -- Button Fields
    [SerializeField]
    private Button exitButton;

    // Member Variables -- Menu Manager Field
    private GameObject menuManager;

    private MenuManager menuManagerScript;

    // Member Variables -- AudioSource
    [SerializeField]
    private AudioSource buttonClickedAudioSource;


    // Start is called before the first frame update
    void Start()
    {
        // Add Listener to the nextButton variable
        exitButton.onClick.AddListener(LoadMainMenu);

        // Instantiate the menuManager variable by finding a gameObject with the tag "MenuManager"
        menuManager = GameObject.FindGameObjectWithTag("MenuManager");

        // Get the menuManager script from the menuManager gameObject and
        // designate it into the menuManagerScript variable
        menuManagerScript = menuManager.GetComponent<MenuManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // ONCLICK LISTENER METHODS

        // Method: Destroy this scene and load the Main Menu
        public void LoadMainMenu()
        {
            // Play the Button Clicked Sound
            menuManagerScript.menuAudioManagerScript.PlayButtonClickedSound(buttonClickedAudioSource);

            // Unload the Credits Scene using Async Loading
            menuManagerScript.UnloadScene("Credits");

            // Load the Main Menu using Async Loading
            menuManagerScript.LoadScene("MainMenu");
        }
}
