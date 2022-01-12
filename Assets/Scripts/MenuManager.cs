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


    // Member Variables -- bool
    private bool isMenuSet = false;


    // Awake is called before Start
    void Awake()
    {
        // Make sure the Menu Manager (this GameObject) is always available between scenes
        DontDestroyOnLoad(gameObject);

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
        public void LoadGamePlay()
        {
            // Load GamePlay using Async Loading
            StartCoroutine(loadManagerScript.LoadScene(LoadManager.SceneMode.GamePlay));

        }



}
