using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {
	public GameObject exitPortal;  // Entering this protal, robot emerges from the exit.

	private float INTERACTION_DISTANCE = 0.1f;  // Get this close to a portal and we activate it.	
	private Robot r;
	private Portal exitP;
	private bool active = false;
	private GameObject mainCamera;
	
	// Use this for initialization
	void Start () {
		r = GameObject.Find("Robot Butler").GetComponent<Robot>();
		mainCamera = GameObject.Find("Main Camera");
		exitP = exitPortal.GetComponent<Portal>();
	}

	// Update is called once per frame
	void Update () {
		if (active && r.CloseEnough(transform.position, INTERACTION_DISTANCE)) {
			// Move the robot to the target.
			r.MoveToLocation(exitP.ExitLocation());
			r.SetPlayerHasControl(false);

			// Set the camera to be the x coordinate of the room of the exit.
			Vector3 newRoomPos = exitPortal.transform.parent.position;
			Vector3 oldCameraPos = mainCamera.transform.position;
			mainCamera.transform.position = new Vector3(newRoomPos.x, oldCameraPos.y, oldCameraPos.z);

			// Deactivate.
			active = false;
		}
	}

	void OnMouseUp() {
		active = true;
	}

	// When the robot exits this portal, it appears here.
	private Vector3 ExitLocation() {
		float displacement = 0.7f;
		float leftOrRight = name.Contains("Left") ? 1.0f : -1.0f;
		return transform.position + new Vector3(leftOrRight * displacement, 0.0f, 0.0f);
	}
}
