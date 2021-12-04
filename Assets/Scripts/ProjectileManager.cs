using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    // Member variables for the hot-sauce capsule projectile
    private const float TIME_DURATION = 0.3f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DoLerp();
    }

    // Method for doing the lerp movement
    private void DoLerp()
    {
        // Create a new variable and make it get the current position of the Hotsauce Spray
        Vector3 oldPos = this.transform.position;

        // Create a new variable that stores the end position of the Hotsauce Spray
        Vector3 newPos = new Vector3(this.transform.position.x, this.transform.position.y + 1.0f);

        // Divide the current time.deltaTime by 2.0f (Time duration)
        float timeFraction = Time.deltaTime / TIME_DURATION;

        // Do the lerp method
        this.transform.position = Vector3.Lerp(oldPos, newPos, timeFraction);
    }

}
