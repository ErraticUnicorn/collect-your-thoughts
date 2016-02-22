using UnityEngine;
using System.Collections;

public class positive_thought : MonoBehaviour {

	public float speed = 5f;
	public float time = .5f;
	public bool hasLeftConsciousness;
	private GameObject player;
	private float exitDir = 1;
	private Vector3 dir = new Vector3();

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Marker");
		dir = transform.position - player.transform.position;
	}

	void Awake() {
		hasLeftConsciousness = false;
	}
	
	// Update is called once per frame
	void Update () {
		dir.x += (Random.value - 0.5f) * Time.deltaTime * 10;
		dir.y += (Random.value - 0.5f) * Time.deltaTime * 10;
		dir.Normalize();
		transform.Translate(exitDir * dir * speed * 0.5f * Time.deltaTime);
	}

	void OnTriggerExit(Collider collisionInfo) {
		if (collisionInfo.gameObject.name == "Skull") {
			exitDir = 0;
			hasLeftConsciousness = true;
			StartCoroutine (WaitAndDestroy ());
		}

	}
	void OnEnable() {
		gameObject.tag = "positive";
	}

	IEnumerator WaitAndDestroy() {
		yield return new WaitForSeconds (time);
		Destroy (this.gameObject);
	}
		
}

