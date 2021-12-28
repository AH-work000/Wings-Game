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
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
    }


    // Method: Restart the Entire Gameplay Scene
    public void RestartGame()
    {
        // Unload the Gameover Scene using Async Loading
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadScene(0);
    }

}
