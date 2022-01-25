using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Member Variables -- LoadManager Fields
    public GameObject loadManager;

    private LoadManager loadManagerScript;


    // Member Variables -- AudioManager Fields
    public GameObject menuAudioManager;
    
    public MenuAudioManager menuAudioManagerScript;


    // Member Variables -- Gamemanager Fields
    /*[SerializeField]
    private GameManager gameManagerScript; */
    [SerializeField]
    private GameObject gameManager;

    private GameManager gameManagerScript;


    // Member Variables -- Menu Background Music AudioSource Fields
    [SerializeField]
    private AudioSource menuBackgroundAudioSource;


    // Member Variables -- bool
    private bool isMenuSet = false;

    private bool isBackgroundMusicPlayed = false;


    // Member Variables -- List of instances of MenuManager (GameObject)
    private GameObject[] menuManagerGameObjectList;



    // Awake is called before Start
    void Awake()
    {
        // Get a list of gameObjects that have the tag "MenuManager" 
        menuManagerGameObjectList = GameObject.FindGameObjectsWithTag("MenuManager");

        // Check if there is more than one instance of MenuManager
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

        // Get the script component of the gameManager gameObject and make it a reference to the
        // gameManagerScript variable
        gameManagerScript = gameManager.GetComponent<GameManager>();
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
        // Play the Background Menu Music
        if (!isBackgroundMusicPlayed && loadManagerScript.isTheCurrentScene(LoadManager.SceneMode.MainMenu))
        {
            StartCoroutine(menuAudioManagerScript.PlayBackgroundMusic(menuBackgroundAudioSource));

            // Make the isBackgroundMusicPlayed bool to be true so that the background
            // music is only played once
            isBackgroundMusicPlayed = true;
        }

    }


    // FUNCTIONS AND PROCEDURES


        // Method: Load the GamePlay Scene and remove the Menu Audio Manager
        public IEnumerator LoadGamePlay(string mode)
        {
            yield return new WaitForSeconds(0.15f);

            // Stop the Menu Background Audio Source from Playing
            menuAudioManagerScript.StopBackgroundMusic(menuBackgroundAudioSource);

            // Load GamePlay using Async Loading
            StartCoroutine(loadManagerScript.LoadScene(LoadManager.SceneMode.GamePlay));
        }



        // Method: Link the UI Controllers to the Load Manager to Load Scene
        public void LoadScene(string sceneMode)
            {
                switch (sceneMode)
                {
                    case "MainMenu": StartCoroutine(loadManagerScript.LoadScene(LoadManager.SceneMode.MainMenu)); break;
                    case "GameMode": StartCoroutine(loadManagerScript.LoadScene(LoadManager.SceneMode.GameMode)); break;
                    case "GamePlay": StartCoroutine(loadManagerScript.LoadScene(LoadManager.SceneMode.GamePlay)); break;
                    case "GameOver": StartCoroutine(loadManagerScript.LoadSceneOverAnotherScene(LoadManager.SceneMode.GameOver)); break;
                    case "TutorialPageOne": StartCoroutine(loadManagerScript.LoadScene(LoadManager.SceneMode.TutorialPageOne)); break;
                    case "TutorialPageTwo": StartCoroutine(loadManagerScript.LoadScene(LoadManager.SceneMode.TutorialPageTwo)); break;
                    case "Credits": StartCoroutine(loadManagerScript.LoadScene(LoadManager.SceneMode.Credits)); break;
                }

                if (sceneMode.Equals("Restart"))
                {
                    StartCoroutine(loadManagerScript.RestartGame());
                    isBackgroundMusicPlayed = false;
                }

            }


            // Method: Link the UI Controllers to the Load Manager to Unload Scene
            public void UnloadScene(string sceneMode)
            {
                switch (sceneMode)
                {
                    case "MainMenu": StartCoroutine(loadManagerScript.UnloadScene(LoadManager.SceneMode.MainMenu)); break;
                    case "GameMode": StartCoroutine(loadManagerScript.UnloadScene(LoadManager.SceneMode.GameMode)); break;
                    case "GamePlay": StartCoroutine(loadManagerScript.UnloadScene(LoadManager.SceneMode.GamePlay)); break;
                    case "GameOver": StartCoroutine(loadManagerScript.UnloadScene(LoadManager.SceneMode.GameOver)); break;
                    case "TutorialPageOne":  StartCoroutine(loadManagerScript.UnloadScene(LoadManager.SceneMode.TutorialPageOne)); break;
                    case "TutorialPageTwo": StartCoroutine(loadManagerScript.UnloadScene(LoadManager.SceneMode.TutorialPageTwo)); break;
                    case "Credits": StartCoroutine(loadManagerScript.UnloadScene(LoadManager.SceneMode.Credits)); break;
                }
            
            }


            // Method: Link the Game Manager to the Load Manager on checking if the current scene is 
            public bool isTheCurrentScene(string sceneMode)
            {
                switch (sceneMode)
                {
                    case "GameMode": return loadManagerScript.isTheCurrentScene(LoadManager.SceneMode.GamePlay);
                    case "GamePlay": return loadManagerScript.isTheCurrentScene(LoadManager.SceneMode.GamePlay);  
                    case "GameOver": return loadManagerScript.isTheCurrentScene(LoadManager.SceneMode.GameOver);
                    default : return false;
                }
            }
}
