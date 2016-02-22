using UnityEngine;
using System.Collections;

public class dopamine_burst : MonoBehaviour {

	public float burstDissapationTime = .1f;
	SphereCollider collider;
	GameObject conscious;
	// Use this for initialization
	void Start () {
		collider = this.gameObject.GetComponent<SphereCollider> ();
		conscious = GameObject.Find ("Conscious");
		collider.enabled = false;
	}

	void Update() {
		this.transform.position = conscious.transform.position;
	}

	public void Burst() {
		collider.enabled = true;
		StartCoroutine(Dissapate ());
	}

	public IEnumerator Dissapate() {
		yield return new WaitForSeconds (burstDissapationTime);
		collider.enabled = false;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "negative") {
			negative_thought neg_behave = other.gameObject.GetComponent<negative_thought> ();
			positive_thought pos_behave = other.gameObject.GetComponent<positive_thought> ();
			neg_behave.enabled = false;
			pos_behave.enabled = true;
		}
	}
}
