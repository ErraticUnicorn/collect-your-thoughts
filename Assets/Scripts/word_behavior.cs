using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Xml;
using System.IO;

public class word_behavior : MonoBehaviour {

	float delay = 1.0f;
	public Text moodText;
	public string[] goodText = new string[] {"SMILE", "HAPPY", "JOY", "GLAD", "ECSTATIC", "SWEETNESS", "DREAMS", "PASSION", "HOPES", "FRIENDS", "MEANING", "ACHIEVE", "LOVE", "ROMANCE"};
	public string[] badText = new string[] {"FROWN", "SCOWL", "CRAMP", "FAIL", "ANNOYED", "GRUMPY", "OUTRAGED", "TENSE", "DISSAPOINTMENT", "HEARTBREAK", "YELLED", "NAUSEOUS"};
	public string[] neutralText = new string[] {"NORMAL", "ROTE", "NOTHING", "EVERYTHING", "FLUFFY", "MEH", "SAME OLD", "ANOTHER DAY", "MEANINGLESS", "INDIFFERENT", "WHAT'S NEW?"};


	// Use this for initialization
	void Start () {
		//Xml loading WIP
		//this.loadDictionary ();
		moodText = GameObject.Find ("MoodText").GetComponent<Text> ();
		moodText.text = "";
	}

	void Update() {

		if (moodText.text != "") {
			StartCoroutine (WaitAndDisable ());
		}
	}


	
	// Update is called once per frame
	IEnumerator WaitAndDisable(){
		yield return new WaitForSeconds (delay);
		moodText.text = "";
	}

	public void setGoodThought() {
		moodText.text = goodText[Random.Range(0, (goodText.Length -1))];
	}

	public void setNeutralThought() {
		moodText.text = neutralText[Random.Range(0, (neutralText.Length -1))];
	}

	public void setBadThought() {
		moodText.text = badText[Random.Range(0, (badText.Length -1))];
	}
	/* wiki.unity3d.com/index.php?title=Saving_and_Loading_Data:_XmlSerializer
	private NegativeWordContainer loadDictionary() {
		NegativeWordContainer negWordContainer = NegativeWordContainer.Load(Path.Combine(Application.dataPath, "Resources/Words/words.xml"));
		return negWordContainer;
	}*/
}
