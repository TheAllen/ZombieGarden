using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	private GameObject parent;
	private StarDisplay starDisplay;

	// Use this for initialization
	void Start () {
		parent = GameObject.Find ("Defenders");
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	Vector2 SnapToGrid(Vector2 rawWorldPos){
		float newX = Mathf.RoundToInt (rawWorldPos.x);
		float newY = Mathf.RoundToInt (rawWorldPos.y);
		return new Vector2 (newX, newY);
	}

	void SpawnDefender (Vector2 roundedPos, GameObject defender)
	{
		Quaternion zeroRotation = Quaternion.identity;
		GameObject newDefender = Instantiate (defender, roundedPos, zeroRotation) as GameObject;
		newDefender.transform.parent = parent.transform;
	}

	void OnMouseDown(){
		Vector2 rawPos = CalculateWorldPointOfMouseClick ();
		Vector2 roundedPos = SnapToGrid (rawPos);
		GameObject defender = Button.selectedDefender;

		int defenderCost = defender.GetComponent<Defender> ().starCost;
		if (starDisplay.UseStars (defenderCost) == StarDisplay.Status.SUCCESS) {
			SpawnDefender (roundedPos, defender);
		} else {
			Debug.Log ("Insufficient stars to spawn");
		}
	}

	Vector2 CalculateWorldPointOfMouseClick(){
		Camera cam = GameObject.FindObjectOfType<Camera> ();
		Vector2 position = cam.ScreenToWorldPoint (new Vector2 (Input.mousePosition.x, Input.mousePosition.y));
		return position;
	}

}
