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
    [SerializeField]
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

            // Unload the Tutorial Page One using Async Loading
            StartCoroutine(menuManagerScript.loadManagerScript.UnloadScene(LoadManager.SceneMode.TutorialPageTwo));

            // Load the Tutorial Page Two using Async Loading
            StartCoroutine(menuManagerScript.loadManagerScript.LoadScene(LoadManager.SceneMode.MainMenu));
        }


        // Method: Destroy this scene and load the page 2 tutorial page
        public void LoadPageOneTutorial()
        {
            // Play the Button Clicked Sound
            menuManagerScript.menuAudioManagerScript.PlayButtonClickedSound(buttonClickedAudioSource);

            // Unload the Tutorial Page One using Async Loading
            StartCoroutine(menuManagerScript.loadManagerScript.UnloadScene(LoadManager.SceneMode.TutorialPageTwo));

            // Load the Tutorial Page Two using Async Loading
            StartCoroutine(menuManagerScript.loadManagerScript.LoadScene(LoadManager.SceneMode.TutorialPageOne)); 
        }
}
