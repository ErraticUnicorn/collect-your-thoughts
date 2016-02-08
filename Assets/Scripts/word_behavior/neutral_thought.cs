using UnityEngine;
using System.Collections;

public class neutral_thought : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnEnable() {
		gameObject.tag = "neutral";
	}
}
