using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class score_tracker : MonoBehaviour {
	public Text scoreText;
	public int score;

	// Use this for initialization
	void Start () {
		score = 0;
		scoreText = GameObject.Find ("Score").GetComponent<Text> ();
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
		if (score < -10) {
			//scoreText.text = "Mood: Depressed";
		} 
		if (score > 10) {
			//scoreText.text = "Mood: At Peace";
		}
	}
}
