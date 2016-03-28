using UnityEngine;
using System.Collections;

public class convert_thought : MonoBehaviour {

		void OnCollisionEnter(Collision collision) {
		Debug.Log ("A thought has collided with " + collision.collider.name);
			if (collision.transform.tag == "negative" || collision.transform.tag == "positive" || collision.transform.tag == "neutral") {
	
				if (collision.transform.tag == "negative") {
					Debug.Log ("A thought is colliding with a negative thought " + this);
				}
	
				if (collision.transform.tag == "positive") {
					Debug.Log ("A thought is colliding with a positive thought " + this);
				}
	
				if (collision.transform.tag == "neutral") {
					Debug.Log ("A thought is colliding with a neutral thought " + this);
					// Enable negative_thought script
					// Disable neutral_thought script
					// Change tag to negative
				}
	
			}
		}
}
