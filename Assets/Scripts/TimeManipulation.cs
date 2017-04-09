using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManipulation : MonoBehaviour {

    public float elapsedTime = 0.0f;
    public float timeStep = 0.02f;
    bool isPlaying = false;
	public float timeMultiplier = 1.0f;
    bool fwd = false;
    bool rwd = false;

	public Canvas canvus;
	private Text playerStateText;
    private ButtonEvents leftButtons;
    // Use this for initialization
    void Start () {
		playerStateText = canvus.GetComponent<Text>();
        //playerStateText.text = (isPlaying ? "Play   " : "Pause   ") + timeMultiplier + "x";
        if(isPlaying)
        {
            GameObject.FindWithTag("PauseButton").GetComponent<Image>().enabled = false;
            GameObject.FindWithTag("PlayButton").GetComponent<Image>().enabled = true;
        } else
        {
            GameObject.FindWithTag("PlayButton").GetComponent<Image>().enabled = false;
            GameObject.FindWithTag("PauseButton").GetComponent<Image>().enabled = true;
        }

        GameObject mainCamera = GameObject.FindWithTag("MainCamera");
        GameObject leftController = mainCamera.GetComponent<SteamVR_ControllerManager>().left;
        print(leftController);
        leftButtons = leftController.GetComponent<ButtonEvents>();
    }
	
	// Update is called once4 per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) || leftButtons.centerPressed) { 
			isPlaying = !isPlaying;
            fwd = false;
            rwd = false;
        }
        if (isPlaying) {
			elapsedTime += timeStep * timeMultiplier;
		}

		if (Input.GetKey (KeyCode.LeftArrow) || leftButtons.rwd) {
			isPlaying = false;
            rwd = true;
            fwd = false;
			elapsedTime -= timeStep * timeMultiplier;
        }
		if (Input.GetKey (KeyCode.RightArrow) || leftButtons.fwd) {
			isPlaying = false; 
			elapsedTime += timeStep * timeMultiplier;
            rwd = false;
            fwd = true;
        }
		if (Input.GetKeyDown (KeyCode.UpArrow) || leftButtons.increaseMultiplier) {
			timeMultiplier = timeMultiplier * 2 <= 4 ? timeMultiplier * 2 : timeMultiplier;
        }
		if (Input.GetKeyDown (KeyCode.DownArrow) || leftButtons.decreaseMultiplier) {
			timeMultiplier = timeMultiplier / 2 >= 0.25f ? timeMultiplier / 2 : timeMultiplier;
        }

        foreach (GameObject proton in GameObject.FindGameObjectsWithTag("Proton")) {
            if (proton.GetComponent<ParticlePosition>().shouldDisappear && elapsedTime >= proton.GetComponent<ParticlePosition>().disappearAfter) {
                proton.GetComponent<Renderer>().enabled = false;
            }
            else if (proton.GetComponent<ParticlePosition>().shouldDisappear && elapsedTime < proton.GetComponent<ParticlePosition>().disappearAfter) {
                proton.GetComponent<Renderer>().enabled = true;
            }
        }

        foreach (GameObject particle in GameObject.FindGameObjectsWithTag("Particle"))
        {
            if (particle.GetComponent<ParticlePosition>().shouldAppear && elapsedTime >= particle.GetComponent<ParticlePosition>().appearAfter)
            {
                particle.GetComponent<Renderer>().enabled = true;
            }
            else if (particle.GetComponent<ParticlePosition>().shouldAppear && elapsedTime < particle.GetComponent<ParticlePosition>().appearAfter)
            {
                particle.GetComponent<Renderer>().enabled = false;
            }
        }

        //playerStateText.text = (isPlaying ? "Play   " : "Pause   ") + timeMultiplier + "x";
        GameObject.FindWithTag("multiplyerText").GetComponent<Text>().text = timeMultiplier + "x";

        if (isPlaying)
        {
            GameObject.FindWithTag("PauseButton").GetComponent<Image>().enabled = false;
            GameObject.FindWithTag("PlayButton").GetComponent<Image>().enabled = true;
        }
        else
        {
            GameObject.FindWithTag("PlayButton").GetComponent<Image>().enabled = false;
            GameObject.FindWithTag("PauseButton").GetComponent<Image>().enabled = true;
        }

        // Show active ffwd symbol
        if (fwd)
        {
            GameObject.FindWithTag("ffwdButton").GetComponent<Image>().enabled = false;
            GameObject.FindWithTag("ffwdButton-active").GetComponent<Image>().enabled = true;
        }
        else
        {
            GameObject.FindWithTag("ffwdButton").GetComponent<Image>().enabled = true;
            GameObject.FindWithTag("ffwdButton-active").GetComponent<Image>().enabled = false;
        }

        if (rwd)
        {
            GameObject.FindWithTag("rwdButton").GetComponent<Image>().enabled = false;
            GameObject.FindWithTag("rwdButton-active").GetComponent<Image>().enabled = true;
        }
        else
        {
            GameObject.FindWithTag("rwdButton").GetComponent<Image>().enabled = true;
            GameObject.FindWithTag("rwdButton-active").GetComponent<Image>().enabled = false;
        }

        fwd = false;
        rwd = false;
    }
}
