using UnityEngine;
using System.Collections;

public class ZoomCamera : MonoBehaviour {

	GameObject stage;
	GameObject backgroundEnvironment;
	Vector3 startingScale;
	Vector3 startingPosition;
	Vector3 destinationScale;
	Vector3 destinationPosition;
	private float startTime;
	private float journeyLength;
	private GameObject skull;
	float distCovered;
	float fracJourney;
	public bool isZoomed;
	public bool isFadedOut;
	SpriteRenderer environmentSprite;

	public float speed = 1.0F;


	// Use this for initialization
	void Start () {
		skull = GameObject.Find ("Skull");
		stage = GameObject.FindGameObjectWithTag ("stage");
		backgroundEnvironment = GameObject.FindGameObjectWithTag ("background");
		destinationScale = new Vector3 (1f, 1f, 1f);
		destinationPosition = new Vector3 (0f, 0f, 0f);
		startingScale = stage.transform.localScale;
		startingPosition = stage.transform.position;

		startTime = Time.time;
		journeyLength = Vector3.Distance(startingPosition, startingScale);
		environmentSprite = backgroundEnvironment.GetComponent<SpriteRenderer> ();
	}

	void Awake () {
		isZoomed = false;
	}

	// Update is called once per frame
	void Update () {
		distCovered = (Time.time - startTime) * speed;
		fracJourney = distCovered / journeyLength;
		if (isZoomed) {
			FadeOut ();
		} else {
			ZoomIn ();
		}
	}

	void ZoomIn () {
		Vector3 skullEnd = new Vector3 (0f, 0f, -7.03f);

		stage.transform.position = Vector3.Lerp(startingPosition, destinationPosition, fracJourney);
		stage.transform.localScale = Vector3.Lerp (startingScale, destinationScale, fracJourney);
		if(Vector3.Distance(skull.transform.position, skullEnd) > .1f){
			Vector3 directionOfTravel = skullEnd - skull.transform.position;
			directionOfTravel.Normalize();

			skull.transform.Translate(
				0f,
				0f,
				(directionOfTravel.z * speed * Time.deltaTime),
				Space.World);
		}
		if (fracJourney > 1) {
			isZoomed = true;
		}
	}

	void FadeOut () {
		environmentSprite.color = Color.Lerp (environmentSprite.color, Color.clear, fracJourney);
		if(fracJourney > 1) {
			isFadedOut = true;
		}
	}
}
