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
	// Use this for initialization
	void Start () {
		playerStateText = canvus.GetComponent<Text>();
        //playerStateText.text = (isPlaying ? "Play   " : "Pause   ") + timeMultiplier + "x";
        if(isPlaying)
        {
            GameObject.Find("Main Camera/HUD/PlayerUI/PauseButton").GetComponent<Image>().enabled = false;
            GameObject.Find("Main Camera/HUD/PlayerUI/PlayButton").GetComponent<Image>().enabled = true;
        } else
        {
            GameObject.Find("Main Camera/HUD/PlayerUI/PlayButton").GetComponent<Image>().enabled = false;
            GameObject.Find("Main Camera/HUD/PlayerUI/PauseButton").GetComponent<Image>().enabled = true;
        }

		protons = GameObject.FindGameObjectsWithTag ("Proton");
		subparticles = GameObject.FindGameObjectsWithTag ("Particle");
		protonSubs = GameObject.FindGameObjectsWithTag ("ProtonSub");
    }
	
	// Update is called once4 per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) { 
			isPlaying = !isPlaying;
            fwd = false;
            rwd = false;
        }
        if (isPlaying) {
			elapsedTime += timeStep * timeMultiplier;
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			isPlaying = false;
            rwd = true;
            fwd = false;
			elapsedTime -= timeStep * timeMultiplier;
        }
		if (Input.GetKey (KeyCode.RightArrow)) {
			isPlaying = false; 
			elapsedTime += timeStep * timeMultiplier;
            rwd = false;
            fwd = true;
        }
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			timeMultiplier = timeMultiplier * 2 <= 4 ? timeMultiplier * 2 : timeMultiplier;
        }
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
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

		foreach (GameObject pro in protonSubs) {
			if (pro.GetComponent<SubparticlePosition>().shouldDisappear && elapsedTime >= pro.GetComponent<SubparticlePosition>().disappearAfter) {
				pro.GetComponent<Renderer>().enabled = false;
			}
			else if (pro.GetComponent<SubparticlePosition>().shouldDisappear && elapsedTime < pro.GetComponent<SubparticlePosition>().disappearAfter) {
				pro.GetComponent<Renderer>().enabled = true;
			}
		}

        //playerStateText.text = (isPlaying ? "Play   " : "Pause   ") + timeMultiplier + "x";
        GameObject.Find("Main Camera/HUD/PlayerUI/multiplyerText").GetComponent<Text>().text = timeMultiplier + "x";

        if (isPlaying)
        {
            GameObject.Find("Main Camera/HUD/PlayerUI/PauseButton").GetComponent<Image>().enabled = false;
            GameObject.Find("Main Camera/HUD/PlayerUI/PlayButton").GetComponent<Image>().enabled = true;
        }
        else
        {
            GameObject.Find("Main Camera/HUD/PlayerUI/PlayButton").GetComponent<Image>().enabled = false;
            GameObject.Find("Main Camera/HUD/PlayerUI/PauseButton").GetComponent<Image>().enabled = true;
        }

        // Show active ffwd symbol
        if (fwd)
        {
            GameObject.Find("Main Camera/HUD/PlayerUI/ffwdButton").GetComponent<Image>().enabled = false;
            GameObject.Find("Main Camera/HUD/PlayerUI/ffwdButton-active").GetComponent<Image>().enabled = true;
        }
        else
        {
            GameObject.Find("Main Camera/HUD/PlayerUI/ffwdButton").GetComponent<Image>().enabled = true;
            GameObject.Find("Main Camera/HUD/PlayerUI/ffwdButton-active").GetComponent<Image>().enabled = false;
        }

        if (rwd)
        {
            GameObject.Find("Main Camera/HUD/PlayerUI/rwdButton").GetComponent<Image>().enabled = false;
            GameObject.Find("Main Camera/HUD/PlayerUI/rwdButton-active").GetComponent<Image>().enabled = true;
        }
        else
        {
            GameObject.Find("Main Camera/HUD/PlayerUI/rwdButton").GetComponent<Image>().enabled = true;
            GameObject.Find("Main Camera/HUD/PlayerUI/rwdButton-active").GetComponent<Image>().enabled = false;
        }

        fwd = false;
        rwd = false;
    }
}
