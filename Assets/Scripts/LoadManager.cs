using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method: Load the Gameover Scene (Game-Over Pop-Up Window)
    public void LoadGameOverScene()
    {
        // Load the Gameover Scene using Async Loading
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
    }


    // Method: Restart the Entire Gameplay Scene
    public void RestartGame()
    {
        // Unload the Gameover Scene using Async Loading
        SceneManager.UnloadSceneAsync(2);
        SceneManager.LoadScene(1);
    }


    // Method: Unload both the Gameover and Gameplay scenes and load the Main Menu
    public void LoadMainMenu()
    {
        // Unload both the Gameover and Gameplay scenes using Async Loading
        SceneManager.UnloadSceneAsync(2);
        SceneManager.UnloadSceneAsync(1);

        // Then Load the Main Scene
        SceneManager.LoadScene(0);

    }

}
