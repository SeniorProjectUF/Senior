using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvents : MonoBehaviour {
    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;

    public bool centerPressed = false;
    public bool fwd = false;
    public bool rwd = false;
    public bool increaseMultiplier = false;
    public bool decreaseMultiplier = false;

    void Awake()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();

    }

    // Use this for initialization
    void Start () {

	}

    void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int)trackedObject.index);
    }

    // Update is called once per frame
    void Update () {
        device = SteamVR_Controller.Input((int)trackedObject.index);
        increaseMultiplier = false;
        decreaseMultiplier = false;
        centerPressed = false;

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            print("Trigger pressed");
        }

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Vector2 touchpad = (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0));

            // If at center of touchpad
            if (touchpad.y < 0.7 && touchpad.y > -0.7 && touchpad.x < 0.7 && touchpad.x > -0.7)
            {
                print("in center");
                centerPressed = true;
            }

            if (touchpad.y > 0.7f)
            {
                // Increase multiplier
                increaseMultiplier = true;
            }

            else if (touchpad.y < -0.7f)
            {
                // Decrease multiplier
                decreaseMultiplier = true;
            }

            if (touchpad.x > 0.7f)
            {
                // Start fwrd
                fwd = true;
            }

            else if (touchpad.x < -0.7f)
            {
                // Start rwnd
                rwd = true;
            }

        }

        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Vector2 touchpad = (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0));
            print("Pressing Touchpad");

            if (touchpad.x > 0.7f)
            {
                // Stop fwrd
                fwd = false;
            }

            else if (touchpad.x < -0.7f)
            {
                // Stop rwnd
                rwd = false;
            }

        }
}

    //void Trigger()
    //{
    //    return 
    //}
}
