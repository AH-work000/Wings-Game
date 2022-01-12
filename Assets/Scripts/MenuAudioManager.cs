using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioManager : MonoBehaviour
{
    // Member Variables -- AudioClips
    [SerializeField]
    private AudioClip buttonClickedSound;


    // Awake is called before Start
    void Awake()
    {
        // Make sure the Menu Audio Manager (this GameObject) is always available between scenes
        DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    // Method: Play the Button Clicked Sound when a UI button is clicked
    public void PlayButtonClickedSound(AudioSource audioSource)
    {
        audioSource.clip = buttonClickedSound;
        audioSource.loop = false;
        audioSource.Play();
    }
}
