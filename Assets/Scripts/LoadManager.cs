using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    // Member variables for SceneMode Selections
    public enum SceneMode {MainMenu, GameMode, GamePlay, GameOver};

    // Member variable for storing a variable reference to the current scene (PRIVATE variable later...)
    public SceneMode currentScene;

    // Awake is called before start
    void Awake()
    {
        // Make sure the LoadManager (this gameObject) is always available between scenes
        DontDestroyOnLoad(gameObject);
       
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
        Debug.Log("Current Scene: " + currentScene);
    }


    // Method: Restart the Game by unloading all current scenes and loading the game menu scene
    public void RestartGame()
    {
        // Unload both the Gameover and Gameplay scenes using Async Loading
        StartCoroutine(UnloadScene(SceneMode.GameOver));
        StartCoroutine(UnloadScene(SceneMode.GamePlay));
         
        // Then Load the Main Scene
        StartCoroutine(LoadScene(SceneMode.MainMenu));
    }



    // Method: Load a Scene using the LoadSceneAsync Method
    public IEnumerator LoadScene(SceneMode scene)
    {
        yield return new WaitForSeconds(0.1f);

        SceneManager.LoadSceneAsync((int)scene);

        // Make the scene param to be the currentScene
        currentScene = scene;
    }


    // Method: Load a Scene over another scene using the LoadSceneAsync Method
    public IEnumerator LoadSceneOverAnotherScene(SceneMode scene)
    {
        yield return new WaitForSeconds(0.1f);

        SceneManager.LoadSceneAsync((int)scene, LoadSceneMode.Additive);

        // Make the scene param to be the currentScene
        currentScene = scene;
    }


    // Method: Unload a Scene using the UnloadSceneAsync Method
    public IEnumerator UnloadScene(SceneMode scene)
    {
        yield return new WaitForSeconds(0.1f);

        SceneManager.UnloadSceneAsync((int)scene);
    }


    // Method: Check if the current scene equals to the scene that is given in the param
    public bool isTheCurrentScene(SceneMode scene)
    {
        return scene == currentScene;
    }


}
