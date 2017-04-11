using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HandlePointer : MonoBehaviour {

    public bool triggerEnter = false;
    private ButtonEvents leftButtons;
    private ButtonEvents rightButtons;
    private GameObject[] InfoBoxes;

    // Use this for initialization
    void Start () {
        GameObject mainCamera = GameObject.FindWithTag("MainCamera");
        GameObject leftController = mainCamera.GetComponent<SteamVR_ControllerManager>().left;
        GameObject rightController = mainCamera.GetComponent<SteamVR_ControllerManager>().right;
        //print(leftController);
        leftButtons = leftController.GetComponent<ButtonEvents>();
        rightButtons = rightController.GetComponent<ButtonEvents>();
        InfoBoxes = GameObject.FindGameObjectsWithTag("InfoBox");
    }

    // Update is called once per frame
    void Update () {
        if ((triggerEnter && leftButtons.triggerPressed) || (triggerEnter && rightButtons.triggerPressed))
        {
            // Change text in text box
            print(gameObject.GetComponent<Renderer>().material.name);
            string material = gameObject.GetComponent<Renderer>().material.name;
            switch(material) {
                case "down quark (Instance)":
                    foreach (GameObject infoBox in InfoBoxes)
                    {
                        infoBox.GetComponent<Text>().text = "This is a down quark";
                    }
                    break;
                case "up quark (Instance)":
                    foreach (GameObject infoBox in InfoBoxes)
                    {
                        infoBox.GetComponent<Text>().text = "This is an up quark";
                    }
                    break;
                case "electron (Instance)":
                    foreach (GameObject infoBox in InfoBoxes)
                    {
                        infoBox.GetComponent<Text>().text = "This is an electron";
                    }
                    break;
                case "Higgs (Instance)":
                    foreach (GameObject infoBox in InfoBoxes)
                    {
                        infoBox.GetComponent<Text>().text = "This is a Higgs";
                    }
                    break;
                case "kaon (Instance)":
                    foreach (GameObject infoBox in InfoBoxes)
                    {
                        infoBox.GetComponent<Text>().text = "This is a kaon";
                    }
                    break;
                case "photon (Instance)":
                    foreach (GameObject infoBox in InfoBoxes)
                    {
                        infoBox.GetComponent<Text>().text = "This is a photon";
                    }
                    break;
                case "pion (Instance)":
                    foreach (GameObject infoBox in InfoBoxes)
                    {
                        infoBox.GetComponent<Text>().text = "This is a pion";
                    }
                    break;
                case "positron (Instance)":
                    foreach (GameObject infoBox in InfoBoxes)
                    {
                        infoBox.GetComponent<Text>().text = "This is a positron";
                    }
                    break;
                case "z boson (Instance)":
                    foreach (GameObject infoBox in InfoBoxes)
                    {
                        infoBox.GetComponent<Text>().text = "This is a z boson";
                    }
                    break;
                default:
                    foreach (GameObject infoBox in InfoBoxes)
                    {
                        infoBox.GetComponent<Text>().text = "This is nothing";
                    }
                    break;

            }
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
