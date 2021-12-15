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


    // Member variables -- AudioSources of GameObjects
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

}
