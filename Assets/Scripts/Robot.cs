using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Robot : MonoBehaviour {

	Vector3 target = Vector3.zero;
	bool moving = false;
	float speed = 5.0f;

	// The distance the robot stands back from objects he walks towards via MoveToLocation. 
	// Can be overwridden with the moveToExactLocation argument.
	private static float STANDBACK_DISTANCE = 0.0f;

	public string holdingObjectName;

	private bool playerHasControl = true;	// Set to false when robot is out of the user's control.

	// Tracks the game ending conditions.
	private NPC father;
	private NPC mother;
	private NPC child;
	private int numCompletedTasks = 0;
	private static int MAX_NUM_COMPLETED_TASKS = 3;

	private GameObject clickTarget; 

	public void SetClickTarget(GameObject o) {
		clickTarget = o;
	}

	public bool IsClickTarget(GameObject o) {
		return clickTarget == o;
	}

	// Use this for initialization
	void Start () {
		father = GameObject.Find("Lazy Father").GetComponent<NPC>();
		mother  = GameObject.Find("Lazy Mother").GetComponent<NPC>();
		child = GameObject.Find("Lazy Child").GetComponent<NPC>();
	}

	// Update is called once per frame
	void Update () {
		if (!Globals.isPaused) {

			if (moving) {
				float step = speed * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, target, step);	

				// Arrived at destination.
				if (transform.position == target) {
					target = Vector3.zero;
					moving = false;
					playerHasControl = true;
				}
			}

			if (holdingObjectName != null && !holdingObjectName.Equals("")) {
				GameObject holdingObject = GameObject.Find(holdingObjectName);
				if (holdingObject == null) {
					holdingObjectName = null;
				} else {
					holdingObject.transform.position = new Vector3(transform.position.x - 0.5f, 
																   transform.position.y + 0.5f, 
															   	   transform.position.z - 0.01f);
				}
			}

			// Check for the endings.
			if (AllFamilyMembersDead()) {
				SceneManager.LoadScene("EndingA");
			} else if (numCompletedTasks >= MAX_NUM_COMPLETED_TASKS) {
				SceneManager.LoadScene("EndingB");
			}
		}
	}

	// Used to take control away from the player, like during a door transition.
	public void SetPlayerHasControl(bool b) {
		playerHasControl = b;
	}

	// Used when an a task is completed successfully.
	public void IncrementNumCompletedTasks() {
		numCompletedTasks++;
	}

	// If 2nd param is false.

	// true, the robot goes to the exact location.  He keeps some distance
	// to prevent clipping into the object.
	public void MoveToLocation(Vector3 location, bool moveToExactLocation=false) {
		if (playerHasControl) {
			// Preserve the robot Y position so that he stays on the ground.
			Vector3 correctedLocation = LocationWithRobotY(location);

			Vector3 standbackOffset = moveToExactLocation ? Vector3.zero :
					// Compute stand-back distance by creating direction vector
					// from corrected locaton back to the current position.
					(transform.position - correctedLocation).normalized * STANDBACK_DISTANCE;

			target = correctedLocation + standbackOffset;
			moving = true;
		}
	}

	// True if the robot is within the interaction distance of the given location.
	public bool CloseEnough(Vector3 location, float distance) {
		// Compare distance by x and z only.
		Vector3 correctedLocation = LocationWithRobotY(location);
		return Vector3.Distance(transform.position, correctedLocation) <= distance;
	}

	// A Vector3 using the robot's y position instead of the one in location.
	private Vector3 LocationWithRobotY(Vector3 location) {
		float robotY = transform.position.y;
		return new Vector3(location.x, robotY, location.z);
	}

	private bool AllFamilyMembersDead() {
		return !father.IsAlive() && !mother.IsAlive() && !child.IsAlive();
	}
}
