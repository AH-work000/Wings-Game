using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class MainMenuUIController : MonoBehaviour
{
    // Member Variables -- Button Fields
    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Button tutorialButton;

    [SerializeField]
    private Button settingButton;

    [SerializeField]
    private Button creditButton;


    // Member Variables -- Menu Manager Field
    private GameObject menuManager;

    private MenuManager menuManagerScript;


    // Member Variables -- AudioSource
    [SerializeField]
    private AudioSource buttonClickedAudioSource;


    // Start is called before the first frame update
    void Start()
    {
        // Add Listener to the playButton variable
        playButton.onClick.AddListener(LoadGameMode);

        // Add Listener to the tutorialButton variable
        tutorialButton.onClick.AddListener(LoadTutorial);

        // Add Listener to the settingButton variable
        settingButton.onClick.AddListener(LoadCredits);

        // Add Listener to the creditButton variable
        creditButton.onClick.AddListener(Quit);

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

        // Method: Destroy this scene and load the Gamemode Menu
        public void LoadGameMode()
        {
            // Play the Button Clicked Sound
            menuManagerScript.menuAudioManagerScript.PlayButtonClickedSound(buttonClickedAudioSource);

            // Unload the Main Menu Scene using Async Loading
            menuManagerScript.UnloadScene("MainMenu");

            // Load the GameMode using Async Loading
            menuManagerScript.LoadScene("GameMode");
        }


        // Method: Destroy this scene and load the Tutorial Page (Scene)
        public void LoadTutorial()
        {
            // Play the Button Clicked Sound
            menuManagerScript.menuAudioManagerScript.PlayButtonClickedSound(buttonClickedAudioSource);

            // Unload the Main Menu Scene using Async Loading
            menuManagerScript.UnloadScene("MainMenu");

            // Load the Tutorial One Page using Async Loading
            menuManagerScript.LoadScene("TutorialPageOne");
        }


        // Method: Destroy this scene and load the Credit Page (Scene)
        public void LoadCredits()
        {
            // Play the Button Clicked Sound
            menuManagerScript.menuAudioManagerScript.PlayButtonClickedSound(buttonClickedAudioSource);

            // Unload the Main Menu Scene using Async Loading
            menuManagerScript.UnloadScene("MainMenu");

            // Load the Credits Scene using Async Loading
            menuManagerScript.LoadScene("Credits");
        }


        // Method: Quit out of the program
        public void Quit()
        {
            // Play the Button Clicked Sound
            menuManagerScript.menuAudioManagerScript.PlayButtonClickedSound(buttonClickedAudioSource);

            // Quit the Application after 0.15f seconds
            Invoke("QuitApp", 0.15f);
        }



    // OTHER METHODS

        // Method: Quit the Application
        private void QuitApp()
        {
            Application.Quit();
            EditorApplication.ExitPlaymode();
        }



}
