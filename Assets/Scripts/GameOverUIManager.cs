using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    private LoadManager loadManagerScript;


    // Start is called before the first frame update
    void Start()
    {
        // Add Listener to the restart button variable
        restart.onClick.AddListener(ReloadLevel);

        // Add Listener to the exit button variable
        exit.onClick.AddListener(LoadMainMenu);

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
        loadManagerScript.UnloadScene(LoadManager.SceneMode.GameOver);

        // Load back the Gameplay Scene
        loadManagerScript.LoadScene(LoadManager.SceneMode.GamePlay);
    }


    // Method: Destroy this scene and the Gameplay Scene and load the main menu
    public void LoadMainMenu()
    {
        // Play the Button Clicked Sound 
        gameManagerScript.audioManagerScript.PlayButtonClickedSound(buttonAudioSource);

        // Unload both the Gameover and Gameplay scenes using Async Loading
        loadManagerScript.UnloadScene(LoadManager.SceneMode.GameOver);
        loadManagerScript.UnloadScene(LoadManager.SceneMode.GamePlay);

        // Then Load the Main Scene
        loadManagerScript.LoadScene(LoadManager.SceneMode.MainMenu);
    }
}
