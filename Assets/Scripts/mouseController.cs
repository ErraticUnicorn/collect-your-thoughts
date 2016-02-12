using UnityEngine;
using System.Collections;

public class mouseController : MonoBehaviour {
	public Vector3 conciousPosition;
	Camera thisCamera;

	void Start() {
		thisCamera = GetComponent<Camera>();
	}

	void Update() {
		Ray ray = thisCamera.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
		conciousPosition = ray.origin;
	}
}
