using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUIManager : MonoBehaviour
{
    // Member Variables -- Button Fields
    [SerializeField]
    private Button restart;

    [SerializeField]
    private Button exit;

    // Member Variables -- Audiosource Fields
    [SerializeField]
    private AudioSource buttonAudioSource;

    // Member Variables -- Script Fields
    [SerializeField]
    private GameManager gameManagerScript;

    // Member Variables -- Load Manager Fields
    private GameObject loadManager;
    
    private LoadManager loadManagerScript;


    // Start is called before the first frame update
    void Start()
    {
        // Add Listener to the restart button variable
        restart.onClick.AddListener(ReloadLevel);

        // Add Listener to the exit button variable
        exit.onClick.AddListener(LoadMainMenu);

        // Instantiate the loadManager variable by finding a gameObject with the tag "LoadManager"
        loadManager = GameObject.FindGameObjectWithTag("LoadManager");

        // Get the loadManagerScript from the loadManager gameObject and
        // designate it into the loadManagerScript variable
        loadManagerScript = loadManager.GetComponent<LoadManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }


    // Method: Restart the Gameplay-Level Scene when the Restart Button is Clicked
    public void ReloadLevel()
    {
        // Play the Button Clicked Sound 
        gameManagerScript.audioManagerScript.PlayButtonClickedSound(buttonAudioSource);

        // Restart the game by calling the Restart game method in the Load Manager

        // Unload the Gameover Scene using Async Loading
        StartCoroutine(loadManagerScript.UnloadScene(LoadManager.SceneMode.GameOver));

        // Load back the Gameplay Scene
        StartCoroutine(loadManagerScript.LoadSceneDeletePreviousObjects(LoadManager.SceneMode.GamePlay));
    }


    // Method: Destroy this scene and the Gameplay Scene and load the main menu
    public void LoadMainMenu()
    {
        // Play the Button Clicked Sound 
        gameManagerScript.audioManagerScript.PlayButtonClickedSound(buttonAudioSource);

        Invoke("RestartGame", 0.3f);
    }


    private void RestartGame()
    {
        // Go to the RestartGame method in the load manage script
        loadManagerScript.RestartGame();
    }
}
