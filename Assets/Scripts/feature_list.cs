using UnityEngine;
using System.Collections;

public class feature_list : MonoBehaviour {

	public bool DopamineBurst;
	public bool CoreThoughts;
	private burst_on_collect dopamine_script;

	// Use this for initialization
	void Start () {
		dopamine_script = this.gameObject.GetComponent<burst_on_collect> ();
		if (!DopamineBurst) {
			Destroy (dopamine_script);
			//May require clean up
		}
	}
}
