using UnityEngine;
using System.Collections;

public class good_thought_leaving : MonoBehaviour {

	public Material red;
	public Material black;
	GameObject skullOutline;
	MeshRenderer skullOutlineMesh;
	float delay = 2f;
	ZoomCamera cam;
	// Use this for initialization
	void Start () {
		skullOutline = GameObject.Find ("SkullOutline");
		//cam = GameObject.Find ("Stage").GetComponent<ZoomCamera> ();
		skullOutlineMesh = skullOutline.GetComponent<MeshRenderer>();
		skullOutlineMesh.material = black;
		skullOutline.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		skullOutline.SetActive (true);
	}

	void OnTriggerExit(Collider collision) {
		if (collision.tag == "positive") {
			if (skullOutlineMesh.material == skullOutlineMesh.materials [0]) {
				skullOutlineMesh.material = red;
				StartCoroutine (WaitAndChangeMaterial ());
			}
		}
	}

	IEnumerator WaitAndChangeMaterial() {
		yield return new WaitForSeconds (delay);
		skullOutlineMesh.material = black;
	}
}
