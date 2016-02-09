using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class score_tracker : MonoBehaviour {
	public Text scoreText;
	pause_behavior endState;
	public int score;

	// Use this for initialization
	void Start () {
		score = 0;
		endState = GameObject.Find ("Canvas").GetComponent<pause_behavior> ();
		//scoreText = GameObject.Find ("Score").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddScore(int i) {
		score += i;
		UpdateMood ();
	}

	public int GetScore() {
		return score;
	}

	void UpdateMood() {
		if (score <= -10) {
			endState.Lose ();
			//scoreText.text = "Mood: Depressed";
		} 
		if (score >= 10) {
			endState.Win ();
			//scoreText.text = "Mood: At Peace";
		}
	}
}
