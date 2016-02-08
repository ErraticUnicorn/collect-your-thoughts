using UnityEngine;
using System.Collections;

public class scrolling_background : MonoBehaviour {

	GameObject stageGameObject;
	ZoomCamera zoomCameraScript;
	bool isCurrentlyFadedOut;

	public Vector2 speed = new Vector2(2, 2);
	public Vector2 direction = new Vector2(-1, 0);
	public bool isLinkedToCamera = false;
	private Vector3 startPos;

	void Start() {
		startPos = this.transform.position;
		startPos.x = 3.11f;
		startPos.y = .7f;
		stageGameObject = GameObject.Find ("Stage");
		zoomCameraScript = stageGameObject.GetComponent<ZoomCamera> ();
	}


	void Update()
	{
		isCurrentlyFadedOut = zoomCameraScript.isFadedOut;

		if (isCurrentlyFadedOut) {
			Vector3 movement = new Vector3 (
				                   speed.x * direction.x,
				                   speed.y * direction.y,
				                   0);

			movement *= Time.deltaTime;
			transform.Translate (movement);

			if (isLinkedToCamera) {
				Camera.main.transform.Translate (movement);
			}
			if (this.gameObject.transform.position.x < -320) {
				this.transform.position = startPos;
			}
		}
	}
}
