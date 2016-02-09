using UnityEngine;
using System.Collections;

public class collect : MonoBehaviour {

	private int negScoreValue = -1;
	//neutral thought worth changes on overall mood
	private int neutralScoreValue= 0;
	private int posScoreValue = 1;
	private score_tracker scoreTracker;
	private word_behavior moodText;

	// Use this for initialization
	void Awake () {
		scoreTracker = GameObject.Find ("ScoreTracker").GetComponent<score_tracker> ();
		moodText = GameObject.Find ("MoodTextUpdater").GetComponent<word_behavior>();
	}
	
	// Update is called once per frame
	void Update () {
		NeutralScoreTracker ();
	}

	void NeutralScoreTracker() {
		if (scoreTracker.GetScore () > 0) {
			neutralScoreValue = -1;
		} else if (scoreTracker.GetScore () == 0) {
			neutralScoreValue = 0;
		} else {
			neutralScoreValue = 1;
		}
	}

	void OnTriggerEnter(Collider collision) {
		if (collision.gameObject.name == "Word 1(Clone)") {
			
			if (collision.tag == "negative") {
				scoreTracker.AddScore (negScoreValue);
				moodText.setBadThought ();
			}

			if (collision.tag == "positive") {
				scoreTracker.AddScore (posScoreValue);
				moodText.setGoodThought ();
			}

			if (collision.tag == "neutral") {
				scoreTracker.AddScore (neutralScoreValue);
				moodText.setNeutralThought ();
			}
			Destroy (collision.gameObject);
		}
	}
}
