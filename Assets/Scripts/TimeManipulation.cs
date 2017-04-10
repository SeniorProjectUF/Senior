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
    private GameObject[] protons;
    private GameObject[] subparticles;
    private GameObject[] protonSubs;
    private ButtonEvents leftButtons;
    // Use this for initialization
    void Start () {
		playerStateText = canvus.GetComponent<Text>();
        //playerStateText.text = (isPlaying ? "Play   " : "Pause   ") + timeMultiplier + "x";

        if (isPlaying)
        {
            foreach (GameObject pauseButton in GameObject.FindGameObjectsWithTag("PauseButton"))
            {
                pauseButton.GetComponent<Image>().enabled = false;
            }

            foreach (GameObject playButton in GameObject.FindGameObjectsWithTag("PlayButton"))
            {
                playButton.GetComponent<Image>().enabled = true;
            }
        }
        else
        {
            foreach (GameObject pauseButton in GameObject.FindGameObjectsWithTag("PauseButton"))
            {
                pauseButton.GetComponent<Image>().enabled = true;
            }

            foreach (GameObject playButton in GameObject.FindGameObjectsWithTag("PlayButton"))
            {
                playButton.GetComponent<Image>().enabled = false;
            }
        }
        
        GameObject mainCamera = GameObject.FindWithTag("MainCamera");
        GameObject leftController = mainCamera.GetComponent<SteamVR_ControllerManager>().left;
        print(leftController);
        leftButtons = leftController.GetComponent<ButtonEvents>();
		protons = GameObject.FindGameObjectsWithTag ("Proton");
		subparticles = GameObject.FindGameObjectsWithTag ("Particle");
		protonSubs = GameObject.FindGameObjectsWithTag ("ProtonSub");
    }
	
	// Update is called once4 per frame
	void Update () {
		print((int)(1f / Time.deltaTime));

        if (Input.GetKeyDown(KeyCode.Space) || leftButtons.centerPressed)
        {
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

		foreach (GameObject proton in protons) {
            if (proton.GetComponent<ParticlePosition>().shouldDisappear && elapsedTime >= proton.GetComponent<ParticlePosition>().disappearAfter) {
				proton.GetComponent<Renderer>().enabled = false;
				foreach (Renderer r in proton.GetComponentsInChildren<Renderer>())
					r.enabled = false;
            }
            else if (proton.GetComponent<ParticlePosition>().shouldDisappear && elapsedTime < proton.GetComponent<ParticlePosition>().disappearAfter) {
				proton.GetComponent<Renderer>().enabled = true;
				foreach (Renderer r in proton.GetComponentsInChildren<Renderer>())
					r.enabled = true;
            }
        }

		foreach (GameObject particle in subparticles)
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
        
        foreach (GameObject multiplier in GameObject.FindGameObjectsWithTag("multiplyerText"))
        {
            multiplier.GetComponent<Text>().text = timeMultiplier + "x";
        }

		foreach (GameObject pro in protonSubs) {
			if (pro.GetComponent<SubparticlePosition>().shouldDisappear && elapsedTime >= pro.GetComponent<SubparticlePosition>().disappearAfter) {
				pro.GetComponent<Renderer>().enabled = false;
			}
			else if (pro.GetComponent<SubparticlePosition>().shouldDisappear && elapsedTime < pro.GetComponent<SubparticlePosition>().disappearAfter) {
				pro.GetComponent<Renderer>().enabled = true;
			}
		}

        if (isPlaying)
        {
            foreach (GameObject pauseButton in GameObject.FindGameObjectsWithTag("PauseButton"))
            {
                pauseButton.GetComponent<Image>().enabled = false;
            }

            foreach (GameObject playButton in GameObject.FindGameObjectsWithTag("PlayButton"))
            {
                playButton.GetComponent<Image>().enabled = true;
            }
        }
        else
        {
            foreach (GameObject pauseButton in GameObject.FindGameObjectsWithTag("PauseButton"))
            {
                pauseButton.GetComponent<Image>().enabled = true;
            }

            foreach (GameObject playButton in GameObject.FindGameObjectsWithTag("PlayButton"))
            {
                playButton.GetComponent<Image>().enabled = false;
            }
        }

        // Show active ffwd symbol
        if (fwd)
        {
            foreach (GameObject ffwdButton in GameObject.FindGameObjectsWithTag("ffwdButton"))
            {
                ffwdButton.GetComponent<Image>().enabled = false;
            }

            foreach (GameObject ffwdButtonActive in GameObject.FindGameObjectsWithTag("ffwdButton-active"))
            {
                ffwdButtonActive.GetComponent<Image>().enabled = true;
            }
        }
        else
        {
            foreach (GameObject ffwdButton in GameObject.FindGameObjectsWithTag("ffwdButton"))
            {
                ffwdButton.GetComponent<Image>().enabled = true;
            }

            foreach (GameObject ffwdButtonActive in GameObject.FindGameObjectsWithTag("ffwdButton-active"))
            {
                ffwdButtonActive.GetComponent<Image>().enabled = false;
            }
        }

        if (rwd)
        {
            foreach (GameObject rwdButton in GameObject.FindGameObjectsWithTag("rwdButton"))
            {
                rwdButton.GetComponent<Image>().enabled = false;
            }

            foreach (GameObject rwdButtonActive in GameObject.FindGameObjectsWithTag("rwdButton-active"))
            {
                rwdButtonActive.GetComponent<Image>().enabled = true;
            }
        }
        else
        {
            foreach (GameObject rwdButton in GameObject.FindGameObjectsWithTag("rwdButton"))
            {
                rwdButton.GetComponent<Image>().enabled = true;
            }

            foreach (GameObject rwdButtonActive in GameObject.FindGameObjectsWithTag("rwdButton-active"))
            {
                rwdButtonActive.GetComponent<Image>().enabled = false;
            }
        }

        fwd = false;
        rwd = false;
    }
}
