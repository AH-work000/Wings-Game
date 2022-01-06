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
        // Add Listener to the playButton variable
        playButton.onClick.AddListener(LoadGameMode);

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
}
