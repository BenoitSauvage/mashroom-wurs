using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBehavior : MonoBehaviour {

    public Slider progressBar;
    public float currentScore;
    float playerScore;
    float AIscore;

	// Use this for initialization
	void Start () {
        playerScore = currentScore / 100;
        progressBar.value = playerScore;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {

            progressBar.value += percentValue(5);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            progressBar.value -= percentValue(5);
        }
    }

    float percentValue(float value) { return value / 100; }
}
