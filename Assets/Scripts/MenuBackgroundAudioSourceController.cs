using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackgroundAudioSourceController : MonoBehaviour
{
    // Member Variables -- Menu Manager
    [SerializeField]
    private MenuManager menuManagerScript;

    // Member Variables -- List of instances of Menu Background AudioSource (GameObject)
    private GameObject[] menuBackgroundAudioSourceList;


    // Awake is called before Start
    void Awake()
    {
        // Get a list of gameObjects that have the tag "MenuBackgroundAudioSourceList" 
        menuBackgroundAudioSourceList = GameObject.FindGameObjectsWithTag("MenuBackgroundAudioSource");

        // Check if there is more than one instance of Menu Background AudioSource
        if (menuBackgroundAudioSourceList.Length > 1)
        {

            // Destroy this gameObject
            Destroy(gameObject);
        }
        else
        {

            // Make sure the Menu Background AudioSource (this GameObject) is always available between scenes
            DontDestroyOnLoad(gameObject);
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 

    }
}
