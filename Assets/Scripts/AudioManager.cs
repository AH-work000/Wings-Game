using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Member variables -- AudioClips
    [SerializeField]
    private AudioClip hotSauceSpraySound;

    [SerializeField]
    private AudioSource hotSauceSprayAudioSource;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Method: Play the Hotsauce Spray Sound when the projectile is launched
    public void PlayShootSound()
    {
        hotSauceSprayAudioSource.clip = hotSauceSpraySound;
        hotSauceSprayAudioSource.Play();
    }
}
