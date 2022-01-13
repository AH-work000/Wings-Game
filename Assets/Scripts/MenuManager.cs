using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Member Variables -- LoadManager Fields
    public GameObject loadManager;

    public LoadManager loadManagerScript;


    // Member Variables -- AudioManager Fields
    public GameObject menuAudioManager;
    
    public MenuAudioManager menuAudioManagerScript;


    // Member Variables -- Gamemanager Fields
    [SerializeField]
    private GameManager gameManagerScript;


    // Member Variables -- bool
    private bool isMenuSet = false;


    // Member Variables -- List of instances of MenuManager (GameObject)
    private GameObject[] menuManagerGameObjectList;


    // Awake is called before Start
    void Awake()
    {
        // Get a list of gameObject that have the tag "MenuManager" 
        menuManagerGameObjectList = GameObject.FindGameObjectsWithTag("MenuManager");

        // Check if ther is more than one instance of MenuManager
        if (menuManagerGameObjectList.Length > 1)
        {
            // Destroy this gameObject
            Destroy(gameObject);
        }
        else
        {
            // Make sure the Menu Manager (this GameObject) is always available between scenes
            DontDestroyOnLoad(gameObject);
        }

        
        // Get the script component of the loadManager gameObject and make it a reference to
        // the loadManagerScript variable
        loadManagerScript = loadManager.GetComponent<LoadManager>();


        // Get the script component of the menuAudioManager gameObject and make it a reference to
        // the menuAudioManagerScript variable
        menuAudioManagerScript = menuAudioManager.GetComponent<MenuAudioManager>();

    }


    // Start is called before the first frame update
    void Start()
    {
        // If both the LoadManager and MenuAudioManager is not generated yet, then create it!
        if (!isMenuSet)
        {
            // Generate a LoadManager into the field
            Instantiate(loadManager);

            // Generate a MenuAudioManager into the field
            Instantiate(menuAudioManager);

            // Make the bool to be true so that there are only one
            // LoadManager and MenuAudioManager generated
            isMenuSet = true;

        }
    }


    // Update is called once per frame
    void Update()
    {

        
    }


    // FUNCTIONS AND PROCEDURES

        // Method: Load the GamePlay Scene and remove the Menu Audio Manager
        public void LoadGamePlay(string mode)
        {
            // Load GamePlay using Async Loading
            StartCoroutine(loadManagerScript.LoadScene(LoadManager.SceneMode.GamePlay));

            // Choice == Game Mode
            string choice = mode;

            // Switch for selecting the Game Mode in the Game Manager

            switch (choice)
            {
                case "Easy": gameManagerScript.selectedGameMode = GameManager.GameMode.Easy; break;
                case "Medium": gameManagerScript.selectedGameMode = GameManager.GameMode.Medium; break;
                case "Hard": gameManagerScript.selectedGameMode = GameManager.GameMode.Hard; break;
            }

            // Switch for determining the time multplier based on the Game Mode
            switch (choice)
            {
                case "Easy": gameManagerScript.SelectGameMode(GameManager.GameMode.Easy); break;
                case "Medium": gameManagerScript.SelectGameMode(GameManager.GameMode.Medium); break;
                case "Hard": gameManagerScript.SelectGameMode(GameManager.GameMode.Hard); break;
            }

    }
}
