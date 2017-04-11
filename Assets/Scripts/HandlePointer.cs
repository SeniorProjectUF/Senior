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
                        infoBox.GetComponent<Text>().text = "Down quarks are a fundamental particle. This means that it is not made up of smaller particles. They have a negative charge.";
                    }
                    break;
                case "up quark (Instance)":
                    foreach (GameObject infoBox in InfoBoxes)
                    {
                        infoBox.GetComponent<Text>().text = "Up quarks are a fundamental particle. This means that it is not made up of smaller particles. They have a positive charge.";
                    }
                    break;
                case "electron (Instance)":
                    foreach (GameObject infoBox in InfoBoxes)
                    {
                        infoBox.GetComponent<Text>().text = "Electrons are negatively charged particles. They are thought to be a fundamental particle. This means that they are not made of smaller particles.";
                    }
                    break;
                case "Higgs (Instance)":
                    foreach (GameObject infoBox in InfoBoxes)
                    {
                        infoBox.GetComponent<Text>().text = "The Higgs boson is very massive compared to the other particles. This makes it very difficult to create one because it requires so much energy. This is the main particle scientists are looking for when running these experiments.";
                    }
                    break;
                case "kaon (Instance)":
                    foreach (GameObject infoBox in InfoBoxes)
                    {
                        infoBox.GetComponent<Text>().text = "Kaons are made up of a quark and an antiquark. They helped discover the existence of another type of quark called the strange quark.";
                    }
                    break;
                case "photon (Instance)":
                    foreach (GameObject infoBox in InfoBoxes)
                    {
                        infoBox.GetComponent<Text>().text = "Photons represent the smallest possible amount of light or other electromagnetic radiation. They have no mass or charge. This is a type of boson, a force-carrying particle.";
                    }
                    break;
                case "pion (Instance)":
                    foreach (GameObject infoBox in InfoBoxes)
                    {
                        infoBox.GetComponent<Text>().text = "Pions are a type of meson, a type of particle made up of quarks and antiquarks. They are thought to be responsible for the strong force interactions that occur between protons and neutrons in an atom’s nucleus.";
                    }
                    break;
                case "positron (Instance)":
                    foreach (GameObject infoBox in InfoBoxes)
                    {
                        infoBox.GetComponent<Text>().text = "Positrons are the antimatter version of an electron. They are similar in mass, but a positron has a positive charge.";
                    }
                    break;
                case "z boson (Instance)":
                    foreach (GameObject infoBox in InfoBoxes)
                    {
                        infoBox.GetComponent<Text>().text = "Z bosons don’t have a charge and decay very quickly to more stable particles.";
                    }
                    break;
                case "Transparent (Instance)":
                    foreach (GameObject infoBox in InfoBoxes)
                    {
                        infoBox.GetComponent<Text>().text = "Protons can be found in the nucleus of atoms. They have a positive charge. They are made up of three quarks, two “up” quarks and one “down” quark. You’ll get more information about these quarks soon.";
                    }
                    break;
                default:
                    foreach (GameObject infoBox in InfoBoxes)
                    {
                        //infoBox.GetComponent<Text>().text = "This is nothing";
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
