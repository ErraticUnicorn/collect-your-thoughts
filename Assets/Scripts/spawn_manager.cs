using UnityEngine;
using System.Collections;

public class spawn_manager : MonoBehaviour {

	public GameObject thought;
	public float spawnTime = 3f;
	public Transform[] spawnPoints;
	private GameObject player, skull;
	private negative_thought neg;
	private positive_thought pos;
	private neutral_thought neu;
	// Use this for initialization
	void Start () {
		
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		player = GameObject.Find ("Marker");
		skull = GameObject.Find ("Skull");

	}

	void Spawn() {
		//Turn on component based on score
		float spawnChance = Random.value * 10;

		GameObject newThought = (GameObject) (Instantiate (thought, NextSpawnPosition(), Quaternion.identity));
		neg = newThought.GetComponent<negative_thought> ();
		pos = newThought.GetComponent<positive_thought> ();
		neu = newThought.GetComponent<neutral_thought> ();
		Debug.Log (spawnChance);
		if (spawnChance <= 2f) {
			neu.enabled = true;
		}
		if (spawnChance > 2f && spawnChance < 6f) {
			pos.enabled = true;
		}
		if (spawnChance >= 6f) {
			neg.enabled = true;
		}
	}


	private Vector3 NextSpawnPosition() {
		var skullBounds = skull.GetComponent<Collider> ().bounds;
		var spawnPos = Random.insideUnitCircle;
		spawnPos.Scale (new Vector2 (skullBounds.extents.x, skullBounds.extents.y));
		return new Vector3 (spawnPos.x, spawnPos.y, player.transform.position.z);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
