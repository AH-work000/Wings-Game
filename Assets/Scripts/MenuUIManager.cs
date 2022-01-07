using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
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

    [SerializeField]
    private Button easyButton;

    [SerializeField]
    private Button mediumButton;

    [SerializeField]
    private Button hardButton;


    // Member Variables -- Audiosource Fields
    private GameObject buttonController;

    private AudioSource buttonAudioSource;


    // Member Variables -- Basic Game Manager Fields
    private GameObject basicGameManager;

    private GameManager gameManagerScript;

    // Member Variables -- Load Manager Fields
    private GameObject loadManager;

    private LoadManager loadManagerScript;


    // Awake is the first called before Start
    void Awake()
    {
        // Initialize the gameManagerScript
        InitializeGameManager();

        // Initialize the ButtonAudioSource
        InitializeAudioSource();

        // Initialize the loadManagerScript
        InitializeLoadManager();

        // Make the Menu UI is always available between scenes
        DontDestroyOnLoad(gameObject);

        // Make the buttonAudioSource to be always available between scenes
        DontDestroyOnLoad(buttonAudioSource);

        // Make the gameManagerScript to be always available between scenes
        DontDestroyOnLoad(basicGameManager);

        // Make the loadManagerScript to be always available between scenes
        DontDestroyOnLoad(loadManager);
    }



    // Start is called before the first frame update
    void Start()
    {
        // Add Listener to the playButton variable
        playButton.onClick.AddListener(LoadGameMode);

        // Add Listener to the easyButton variable
        easyButton.onClick.AddListener(LoadEasyMode);

        // Add Listener to the mediumButton variable
        mediumButton.onClick.AddListener(LoadMediumMode);

        // Add Listener to the hardButton variable
        hardButton.onClick.AddListener(LoadHardMode);
    }


    // Update is called once per frame
    void Update()
    {
 

    }


    // Method: Destroy this scene and load the Gamemode Menu
    public void LoadGameMode()
    {
        // Play the Button Clicked Sound 
        gameManagerScript.audioManagerScript.PlayButtonClickedSound(buttonAudioSource);

        // Unload the Main Menu Screen using Async Loading
        loadManagerScript.UnloadScene(LoadManager.SceneMode.MainMenu);

        // Load the GameMode using Async Loading 
        loadManagerScript.LoadScene(LoadManager.SceneMode.GameMode);
    }


    // Method: Load the GamePlay scene in Easy Mode
    public void LoadEasyMode()
    {
        // Initialize the gameManagerScript, buttonAudioSource and loadManagerScript again
        InitializeGameManager();
        InitializeAudioSource();
        InitializeLoadManager();
        gameManagerScript.InitializeLoadManager();


        // Play the Button Clicked Sound 
        gameManagerScript.audioManagerScript.PlayButtonClickedSound(buttonAudioSource);

        // Load the Gameplay scene after 0.8f
        Invoke("LoadGamePlayScene", 0.4f);

        // GAMEMODE == EASY
    }


    // Method: Load the GamePlay scene in Medium Mode
    public void LoadMediumMode()
    {
        // Initialize the gameManagerScript, buttonAudioSource and loadManagerScript again
        InitializeGameManager();
        InitializeAudioSource();
        InitializeLoadManager();
        gameManagerScript.InitializeLoadManager();

        // Play the Button Clicked Sound 
        gameManagerScript.audioManagerScript.PlayButtonClickedSound(buttonAudioSource);

        // Load the Gameplay scene after 0.8f
        Invoke("LoadGamePlayScene", 0.4f);

        // GAMEMODE == MEDIUM
    }


    // Method: LoAd the GamePlay scene in Hard Mode
    public void LoadHardMode()
    {
        // Initialize the gameManagerScript, buttonAudioSource and loadManagerScript again
        InitializeGameManager();
        InitializeAudioSource();
        InitializeLoadManager();
        gameManagerScript.InitializeLoadManager();

        // Play the Button Clicked Sound 
        gameManagerScript.audioManagerScript.PlayButtonClickedSound(buttonAudioSource);

        // Load the Gameplay scene after 0.8f
        Invoke("LoadGamePlayScene", 0.4f);

        // GAMEMODE == HARD
    }


    // Method: Initialize the gameManager Script
    private void InitializeGameManager()
    {
        // Initialize the basicGameManager by finding that object with the tag "BasicGameManager"
        basicGameManager = GameObject.FindGameObjectWithTag("BasicGameManager");

        // Initialize the gameManagerScript by getting the script from the basicGameManager object
        gameManagerScript = basicGameManager.GetComponentInChildren<GameManager>();
    }


   // Method: Initialize the buttonAudioSource
   private void InitializeAudioSource()
   {
        // Initialize the buttonController by finding that object with the tag "ButtonAudioSource"
        buttonController = GameObject.FindGameObjectWithTag("ButtonAudioSource");

        // Initialize the buttonAudioSource by getting the component from the buttonController object
        buttonAudioSource = buttonController.GetComponent<AudioSource>();
   }


    // Method: Initialize the buttonAudioSource
    private void InitializeLoadManager()
    {
        // Initialize the buttonController by finding that object with the tag "ButtonAudioSource"
        loadManager = GameObject.FindGameObjectWithTag("LoadManager");

        // Initialize the buttonAudioSource by getting the component from the buttonController object
        loadManagerScript = loadManager.GetComponent<LoadManager>();
    }


    // Method: Load the Gameplay Scene 
    private void LoadGamePlayScene()
    {
        // Unload the Main Menu Screen using Async Loading
        loadManagerScript.UnloadScene(LoadManager.SceneMode.GameMode);

        // Destroy the buttonAudioSource and gameManagerScript
        Destroy(buttonController);
        Destroy(basicGameManager);

        // Load GamePlay using Async Loading
        loadManagerScript.LoadScene(LoadManager.SceneMode.GamePlay);
    }


}
