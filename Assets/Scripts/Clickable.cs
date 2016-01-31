using UnityEngine;
using System.Collections;

public class Clickable : MonoBehaviour {
	// Can be tweaked to make the robot move to a slightly offset position from the
	// center of the object.
	public Vector3 standbackOffset = Vector3.zero;

	private bool isDoor;

	// Use this for initialization
	void Start () {
		isDoor = name.Contains("Door");
	}
	
	// Update is called once per frame
	void Update () {	
	}

	void OnMouseUp() {
		if (!Globals.isPaused) {
			Robot r = GameObject.Find("Robot Butler").GetComponent<Robot>();
			r.SetClickTarget(gameObject);    // Indicate this game object was clicked on.
			bool moveToExactLocation = isDoor;	// Gotta walk all the way to a door.
			r.MoveToLocation(transform.position + standbackOffset, moveToExactLocation);
		}
	}
}
