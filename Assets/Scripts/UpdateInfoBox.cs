using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UpdateInfoBox : MonoBehaviour
{

    private ButtonEvents leftButtons;
    private ButtonEvents rightButtons;
    private GameObject[] InfoBoxes;
    private int count = 0;

    public string nextScene;
    public string[] transcript;

    // Use this for initialization
    void Start()
    {
        GameObject mainCamera = GameObject.FindWithTag("MainCamera");
        GameObject leftController = mainCamera.GetComponent<SteamVR_ControllerManager>().left;
        GameObject rightController = mainCamera.GetComponent<SteamVR_ControllerManager>().right;
        //print(leftController);
        leftButtons = leftController.GetComponent<ButtonEvents>();
        rightButtons = rightController.GetComponent<ButtonEvents>();
        InfoBoxes = GameObject.FindGameObjectsWithTag("InfoBox");

        // Set default text
        foreach (GameObject infoBox in InfoBoxes)
        {
            infoBox.GetComponent<Text>().text = transcript[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Controls which scene
        if(leftButtons.menuPressed)
        {
            if(count == transcript.Length - 1 && nextScene != "FIN")
            {
                SceneManager.LoadScene(nextScene);
            }
            else if(count == transcript.Length - 1 && nextScene == "FIN")
            {
                Application.Quit();
            }
        }

        // Controls what text should be on screen
        if (rightButtons.menuPressed)
        {
            count += 1;
            print("count: " + count);

            if (count >= transcript.Length - 1)
            {
                count = transcript.Length - 1;
            }

            foreach (GameObject infoBox in InfoBoxes)
            {
                infoBox.GetComponent<Text>().text = transcript[count];
            }
        }
    }
}
