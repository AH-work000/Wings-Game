using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioManager : MonoBehaviour
{
    // Member Variables -- AudioClips
    [SerializeField]
    private AudioClip buttonClickedSound;

    [SerializeField]
    private AudioClip backgroundMenuSound;


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


    // Method: Play the Background Menu Music once the Main Menu Scene have loaded
    public IEnumerator PlayBackgroundMusic(AudioSource audioSource)
    {
        yield return new WaitForSeconds(0.15f);
        audioSource.clip = backgroundMenuSound;
        audioSource.volume = 0.25f;
        audioSource.loop = true;
        audioSource.Play();
    }


    // Method: Stop the Background Menu Music once the Game Mode have been selected
    public void StopBackgroundMusic(AudioSource audioSource)
    {
        audioSource.Stop();
    }



}
