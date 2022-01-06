using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    // Member variables for SceneMode Selections
    public enum SceneMode {MainMenu, GamePlay, GameOver};



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method: Load a Scene using the LoadSceneAsync Method
    public void LoadScene(SceneMode scene)
    {
        SceneManager.LoadSceneAsync((int)scene);
    }


    // Method: Load a Scene over another scene using the LoadSceneAsync Method
    public void LoadSceneOverAnotherScene(SceneMode scene)
    {
        SceneManager.LoadSceneAsync((int)scene, LoadSceneMode.Additive);
    }


    // Method: Unload a Scene using the UnloadSceneAsync Method
    public void UnloadScene(SceneMode scene)
    {
        SceneManager.UnloadSceneAsync((int)scene);
    }

}
