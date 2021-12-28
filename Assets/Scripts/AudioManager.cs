using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Member variables -- AudioClips
    [SerializeField]
    private AudioClip hotSauceSpraySound;

    [SerializeField]
    private AudioClip wingHitSound;

    [SerializeField]
    private AudioClip gameplayMusic;

    [SerializeField]
    private AudioClip gameoverMusic;

    [SerializeField]
    private AudioClip buttonClickedSound; 


    // Member variables -- AudioSources of GameObjects in the Gameplay-Level Scene
    [SerializeField]
    private AudioSource hotSauceSprayAudioSource;

    [SerializeField]
    private AudioSource chickenWingAudioSource;

    [SerializeField]
    private AudioSource backgroundAudioSource;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        
    }

    // ADDITIONAL METHODS 



    // Method: Play the Hotsauce Spray Sound when the projectile is launched
    public void PlayShootSound()
    {
        hotSauceSprayAudioSource.clip = hotSauceSpraySound;
        hotSauceSprayAudioSource.Play();
    }



    // Method: Play the Wing-Hit sound when a projectile hit a chicken wing
    public void PlayHitSound()
    {
        chickenWingAudioSource.clip = wingHitSound;
        chickenWingAudioSource.Play();
    }


    // Method: Play the gameplay background music on loop
    public void PlayGameplayMusic()
    {
        backgroundAudioSource.clip = gameplayMusic;
        backgroundAudioSource.volume = 0.25f;
        backgroundAudioSource.loop = true;
        backgroundAudioSource.Play();
    }


    // Method: Play the game over music
    public IEnumerator PlayGameOverMusic()
    {
        backgroundAudioSource.Stop();
        yield return new WaitForSeconds(0.4f);
        backgroundAudioSource.clip = gameoverMusic;
        backgroundAudioSource.volume = 0.3f;
        backgroundAudioSource.loop = false;
        backgroundAudioSource.Play();
    }


    // Method: Play the Button Clicked Sound when a UI button is clicked
    public void PlayButtonClickedSound(AudioSource audiosource)
    {
        audiosource.clip = buttonClickedSound;
        audiosource.loop= false;
        audiosource.Play();
    }

}
