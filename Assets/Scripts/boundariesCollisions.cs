using UnityEngine;
using System.Collections;

public class boundariesCollisions : MonoBehaviour {
	private GameObject markerGameObject;
	private GameObject consciousSprite;

	// Use this for initialization
	void Start () {
		markerGameObject = GameObject.Find ("Marker");
	}
	
	void OnTriggerEnter(Collider collisionInfo) {
		Debug.Log ("OnTriggerEnter");
		markerGameObject.transform.position = this.transform.position;
		markerGameObject.transform.parent = this.transform;
	}

	void OnTriggerExit(Collider collisionInfo) {
		Debug.Log ("OnTriggerExit");
		transform.DetachChildren ();
	}

}
