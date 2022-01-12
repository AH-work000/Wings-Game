using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModeUIController : MonoBehaviour
{
    // Member Variables -- Button Fields
    [SerializeField]
    private Button easyButton;

    [SerializeField]
    private Button mediumButton;

    [SerializeField]
    private Button hardButton;

    // Member Variables -- Menu Manager Field
    private GameObject menuManager;

    private MenuManager menuManagerScript;

    // Member Variables -- AudioSource
    [SerializeField]
    private AudioSource buttonClickedAudioSource;



    // Start is called before the first frame update
    void Start()
    {
        // Add Listener to the easyButton variable
        easyButton.onClick.AddListener(LoadEasyMode);

        // Add Listener to the mediumButton variable
        mediumButton.onClick.AddListener(LoadMediumMode);

        // Add Listener to the hardButton variable
        hardButton.onClick.AddListener(LoadHardMode);

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


        // Method: Destroy this scene and load the Gameplay scene in Easy Mode
        public void LoadEasyMode()
        {
            // Play the Button Clicked Sound
            menuManagerScript.menuAudioManagerScript.PlayButtonClickedSound(buttonClickedAudioSource);


            // Unload the GameMode Scene using Async Loading
            StartCoroutine(menuManagerScript.loadManagerScript.UnloadScene(LoadManager.SceneMode.GameMode));


            // Call the LoadGameplay method in menuManagerScript to load the gameplay scene
            menuManagerScript.LoadGamePlay();
    }


        // Method: Destroy this scene and load the Gameplay scene in Medium Mode
        public void LoadMediumMode()
        {
            // Play the Button Clicked Sound
            menuManagerScript.menuAudioManagerScript.PlayButtonClickedSound(buttonClickedAudioSource);

        }


        // Method: Destroy this scene and load the Gameplay scene in Hard Mode
        public void LoadHardMode()
        {
            // Play the Button Clicked Sound
            menuManagerScript.menuAudioManagerScript.PlayButtonClickedSound(buttonClickedAudioSource);

        }

}
