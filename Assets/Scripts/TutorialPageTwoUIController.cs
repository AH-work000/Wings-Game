using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPageTwoUIController : MonoBehaviour
{
    // Member Variables -- Button Fields
    [SerializeField]
    private Button exitButton;

    [SerializeField]
    private Button backButton;


    // Member Variables -- Menu Manager Field
    private GameObject menuManager;

    private MenuManager menuManagerScript;


    // Member Variables -- AudioSource
    [SerializeField]
    private AudioSource buttonClickedAudioSource;


    // Start is called before the first frame update
    void Start()
    {
        // Add Listener to the exitButton variable
        exitButton.onClick.AddListener(ReturnToMainMenu);

        // Add Listener to the backButton variable
        backButton.onClick.AddListener(LoadPageOneTutorial);

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

        // Method: Destroy this scene and load the main menu
        public void ReturnToMainMenu()
        {
            // Play the Button Clicked Sound
            menuManagerScript.menuAudioManagerScript.PlayButtonClickedSound(buttonClickedAudioSource);

            // Unload the Tutorial Page Two using Async Loading
            menuManagerScript.UnloadScene("TutorialPageTwo");

            // Load the Main Menu using Async Loading
            menuManagerScript.LoadScene("MainMenu");
        }


        // Method: Destroy this scene and load the page 2 tutorial page
        public void LoadPageOneTutorial()
        {
            // Play the Button Clicked Sound
            menuManagerScript.menuAudioManagerScript.PlayButtonClickedSound(buttonClickedAudioSource);

            // Unload the Tutorial Page Two using Async Loading
            menuManagerScript.UnloadScene("TutorialPageTwo");

            // Load the Tutorial Page One using Async Loading
            menuManagerScript.LoadScene("TutorialPageOne");
        }
}
