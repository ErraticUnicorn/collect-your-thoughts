using UnityEngine;
using System.Collections;

public class core_thought : MonoBehaviour {

	public int negativeCollisions;

	// Use this for initialization
	void Start () {
		negativeCollisions = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "negative") {
			negativeCollisions += 1;
		}
	}
}
