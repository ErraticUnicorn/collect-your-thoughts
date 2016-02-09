using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class pause_behavior : MonoBehaviour {

	GameObject pauseUI;
	Button pauseButton;

	GameObject winUI;
	Button winButton;

	GameObject loseUI;
	Button loseButton;

	// Use this for initialization
	void Start () {
		pauseUI = transform.FindChild("Pause").gameObject;
		pauseButton = pauseUI.gameObject.GetComponent<Button>();
		pauseButton.onClick.AddListener (Resume);
		pauseUI.SetActive (false);

		winUI = transform.FindChild ("WinScreen").gameObject;
		winButton = winUI.gameObject.GetComponent<Button> ();
		winButton.onClick.AddListener (Reset);
		winUI.SetActive (false);

		loseUI = transform.FindChild ("LoseScreen").gameObject;
		loseButton = loseUI.gameObject.GetComponent<Button> ();
		loseButton.onClick.AddListener (Reset);
		loseUI.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))   {
			Pause ();
		}
	}

	void Pause() {
		pauseUI.SetActive(true);
		Time.timeScale = 0;
		Cursor.visible = true;
	}

	void Resume() {
		pauseUI.SetActive (false);
		Time.timeScale = 1;
		Cursor.visible = false;
	}

	public void Win() {
		winUI.SetActive (true);
		Time.timeScale = 0;
		Cursor.visible = true;
	}

	public void Lose() {
		loseUI.SetActive (true);
		Time.timeScale = 0;
		Cursor.visible = true;
	}

	void Reset() {
		Time.timeScale = 1;
		SceneManager.LoadSceneAsync (SceneManager.GetActiveScene().name);
	}
}
