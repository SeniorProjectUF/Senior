using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManipulation : MonoBehaviour {

    public float elapsedTime = 0.0f;
    public float timeStep = 0.02f;
	bool isPlaying = false;
	public float timeMultiplier = 1.0f;

	public Canvas canvus;
	private Text playerStateText;
	// Use this for initialization
	void Start () {
		playerStateText = canvus.GetComponent<Text>();
		playerStateText.text = (isPlaying ? "Play   " : "Pause   ") + timeMultiplier + "x";
	}
	
	// Update is called once4 per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) { 
			isPlaying = !isPlaying; 
		}
		if (isPlaying) {
			elapsedTime += timeStep * timeMultiplier;
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			isPlaying = false;
			elapsedTime -= timeStep * timeMultiplier;
        }
		if (Input.GetKey (KeyCode.RightArrow)) {
			isPlaying = false; 
			elapsedTime += timeStep * timeMultiplier;
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			timeMultiplier = timeMultiplier * 2 <= 4 ? timeMultiplier * 2 : timeMultiplier;
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
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

        playerStateText.text = (isPlaying ? "Play   " : "Pause   ") + timeMultiplier + "x";
    }
}
