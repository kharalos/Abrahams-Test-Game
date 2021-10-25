using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Controller controller;
    bool paused;
    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<Controller>();
        controller.DisplayCursor(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause") && !paused)
        {
            controller.DisplayCursor(true);
            paused = true;
            Debug.Log("Paused");
            //Enable Pause Menu
        }
        else if(Input.GetButtonDown("Pause") && paused)
        {
            controller.DisplayCursor(false);
            paused = false;
            Debug.Log("Unpaused");
            //Disable Pause Menu
        }
    }
}