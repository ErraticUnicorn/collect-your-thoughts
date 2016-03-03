using UnityEngine;
using System.Collections;

public class mouseController : MonoBehaviour {
//	public Vector3 consciousPosition;
	private GameObject consciousGameObject;
	private GameObject markerGameObject;

	Camera thisCamera;

	void Start() {
		UnityEngine.Cursor.visible= false;
		consciousGameObject = GameObject.Find ("Conscious");
		markerGameObject = GameObject.Find ("Marker");
		thisCamera = GetComponent<Camera>();
		consciousGameObject.transform.position = Input.mousePosition;
	}

	void Update() {
		Ray ray = thisCamera.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
		consciousGameObject.transform.position = ray.origin;
	}
}
