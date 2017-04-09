using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePointer : MonoBehaviour {

    public bool triggerEnter = false;
    private ButtonEvents leftButtons;

    // Use this for initialization
    void Start () {
        GameObject mainCamera = GameObject.FindWithTag("MainCamera");
        GameObject leftController = mainCamera.GetComponent<SteamVR_ControllerManager>().left;
        print(leftController);
        leftButtons = leftController.GetComponent<ButtonEvents>();
    }
	
	// Update is called once per frame
	void Update () {
        if (triggerEnter && leftButtons.triggerPressed)
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
