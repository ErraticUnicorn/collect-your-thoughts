using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
	private mouseController mouse_controller;
	private GameObject child;
	// Use this for initialization
	void Start () {
		Camera camera = Camera.main;
		mouse_controller = camera.GetComponent<mouseController>();
		UnityEngine.Cursor.visible= false;
		GameObject conscious = this.gameObject;
		SpriteRenderer marker = conscious.GetComponentInChildren<SpriteRenderer> ();
		child = marker.gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		// update position assignment from mouse_controller
		Debug.Log (mouse_controller.conciousPosition.x);
		this.transform.position = new Vector3(ray.origin.x, ray.origin.y, ray.origin.z);

		Debug.DrawRay(Camera.main.gameObject.transform.position, ray.direction, Color.white);

	}

	void OnTriggerEnter(Collider collisionInfo) {
		child.transform.parent = this.transform;
		child.transform.position = this.transform.position;
	}

	void OnTriggerStay(Collider collisionInfo) {
		//GameObject conscious = this.gameObject;
		//SpriteRenderer marker = conscious.GetComponentInChildren<SpriteRenderer> ();
		//child = marker.gameObject;
		//transform.DetachChildren ();
	}

	void OnTriggerExit(Collider collisionInfo) {
		
		transform.DetachChildren ();
	}
}
