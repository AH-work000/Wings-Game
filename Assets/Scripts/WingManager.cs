using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingManager : MonoBehaviour
{
    // Member variables for the main camera
    private GameObject mainCamera;

    private Camera mainCameraComponent;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the mainCamera GameObject by using the FindGameObjectWithTag method
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        // Initialize the mainCameraComponent by 
        mainCameraComponent = mainCamera.GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {

    }


}
