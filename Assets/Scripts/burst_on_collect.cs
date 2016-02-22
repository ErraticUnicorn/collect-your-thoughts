using UnityEngine;
using System.Collections;

public class burst_on_collect : MonoBehaviour {
	private dopamine_burst dopamine;
	private GameObject dopamineObject;

	// Use this for initialization
	void Awake () {
		dopamineObject = (GameObject) (Instantiate (Resources.Load ("Prefab/DopamineBurst"), this.transform.position, Quaternion.identity));
		dopamine = dopamineObject.GetComponent<dopamine_burst> ();
	}
		

	void OnTriggerEnter(Collider collision) {
		if (collision.gameObject.name == "Thought(Clone)") {
			if (collision.tag == "positive") {
				dopamine.Burst ();
			}
		}
	}
}
