using UnityEngine;
using System.Collections;

public class negative_thought : MonoBehaviour {

	public float speed = 5f;
	private float exitDir = 1;
	private GameObject player;
	private Vector3 dir = new Vector3();

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Marker");
		dir = player.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		dir.x += (Random.value - 0.5f) * Time.deltaTime * 10;
		dir.y += (Random.value - 0.5f) * Time.deltaTime * 10;
		dir.Normalize ();
		this.transform.position = Vector3.MoveTowards (this.transform.position, player.transform.position, speed * Time.deltaTime);
	}

	void OnDestroy() {
		transform.Translate (exitDir * dir * speed * 0.5f * Time.deltaTime);
	}

	void OnEnable() {
		gameObject.tag = "negative";
	}

	void OnTriggerExit(Collider collisionInfo) {
		exitDir = 0;
	}
}
