using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePointer : MonoBehaviour {

    public bool triggerEnter = false;
    private ButtonEvents leftButtons;
    private ButtonEvents rightButtons;

    // Use this for initialization
    void Start () {
        GameObject mainCamera = GameObject.FindWithTag("MainCamera");
        GameObject leftController = mainCamera.GetComponent<SteamVR_ControllerManager>().left;
        GameObject rightController = mainCamera.GetComponent<SteamVR_ControllerManager>().right;
        //print(leftController);
        leftButtons = leftController.GetComponent<ButtonEvents>();
        rightButtons = rightController.GetComponent<ButtonEvents>();
    }
	
	// Update is called once per frame
	void Update () {
        if ((triggerEnter && leftButtons.triggerPressed) || (triggerEnter && rightButtons.triggerPressed))
        {
            print("play stuff");
        }
    }


    public void didEnter()
    {
        triggerEnter = true;
    }

    public void didExit()
    {
        triggerEnter = false;
    }
}
