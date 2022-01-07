using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    // Member variables for SceneMode Selections
    public enum SceneMode {MainMenu, GameMode, GamePlay, GameOver};

    // Member variable for storing a variable reference to the 
    private SceneMode currentScene;


    // Awake is the first called before Start
    void Awake()
    {
        // Make the Menu UI is always available between scenes
        // DontDestroyOnLoad(gameObject);
    }



    // Start is called before the first frame update
    void Start()
    {
        // Initialising the currentScene variable
        currentScene = SceneMode.MainMenu; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method: Load a Scene using the LoadSceneAsync Method
    public void LoadScene(SceneMode scene)
    {
        SceneManager.LoadScene((int)scene);

        // Make the scene param to be the currentScene
        currentScene = scene;
    }


    // Method: Load a Scene over another scene using the LoadSceneAsync Method
    public void LoadSceneOverAnotherScene(SceneMode scene)
    {
        SceneManager.LoadSceneAsync((int)scene, LoadSceneMode.Additive);

        // Make the scene param to be the currentScene
        currentScene = scene;
    }


    // Method: Unload a Scene using the UnloadSceneAsync Method
    public void UnloadScene(SceneMode scene)
    {
        SceneManager.UnloadSceneAsync((int)scene);
    }


    // Method: Check if the current scene equals to the scene that is given in the param
    public bool isTheCurrentScene(SceneMode scene)
    {
        return scene == currentScene;
    }

}
