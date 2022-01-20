using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField]
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

            // Unload the Main Menu Screen using Async Loading
            StartCoroutine(menuManagerScript.loadManagerScript.UnloadScene(LoadManager.SceneMode.MainMenu));

            // Load the GameMode using Async Loading
            StartCoroutine(menuManagerScript.loadManagerScript.LoadScene(LoadManager.SceneMode.GameMode));
        }


        // Method: Destroy this scene and load the Tutorial Page (Scene)
        public void LoadTutorial()
        {
            // Play the Button Clicked Sound
            menuManagerScript.menuAudioManagerScript.PlayButtonClickedSound(buttonClickedAudioSource);

            // Unload the Main Menu Screen using Async Loading
            StartCoroutine(menuManagerScript.loadManagerScript.UnloadScene(LoadManager.SceneMode.MainMenu));

            // Load the Tutorial One Page using Async Loading
            StartCoroutine(menuManagerScript.loadManagerScript.LoadScene(LoadManager.SceneMode.TutorialPageOne));
        }


        // Method: Destroy this scene and load the Credit Page (Scene)
        public void LoadCredits()
        {
            // Play the Button Clicked Sound
            menuManagerScript.menuAudioManagerScript.PlayButtonClickedSound(buttonClickedAudioSource);

        }


        // Method: Quit out of the program
        public void Quit()
        {
            // Play the Button Clicked Sound
            menuManagerScript.menuAudioManagerScript.PlayButtonClickedSound(buttonClickedAudioSource);

        }

}
