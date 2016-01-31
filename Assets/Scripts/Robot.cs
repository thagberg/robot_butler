using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Robot : MonoBehaviour {

	Vector3 target = Vector3.zero;
	bool moving = false;
	float speed = 5.0f;

	public string holdingObjectName;

	private bool playerHasControl = true;	// Set to false when robot is out of the user's control.

	// Tracks the game ending conditions.
	private NPC father;
	private NPC mother;
	private NPC child;
	private int numCompletedTasks = 0;
	private static int MAX_NUM_COMPLETED_TASKS = 10;

	// Use this for initialization
	void Start () {
		father = GameObject.Find("Lazy Father").GetComponent<NPC>();
		mother  = GameObject.Find("Lazy Mother").GetComponent<NPC>();
		child = GameObject.Find("Lazy Child").GetComponent<NPC>();
	}
	
	// Update is called once per frame
	void Update () {
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
			holdingObject.transform.position = transform.position;
		}

		// Check for the endings.
		if (AllFamilyMembersDead()) {
			SceneManager.LoadScene("EndingA");
		} else if (numCompletedTasks >= MAX_NUM_COMPLETED_TASKS) {
			SceneManager.LoadScene("EndingB");
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

	public void MoveToLocation(Vector3 location) {
		if (playerHasControl) {
			target = location;
			moving = true;
		}
	}

	// True if the robot is within the interaction distance of the given location.
	public bool CloseEnough(Vector3 location, float distance) {
		return Vector3.Distance(transform.position, location) <= distance;
	}

	private bool AllFamilyMembersDead() {
		return !father.IsAlive() && !mother.IsAlive() && !child.IsAlive();
	}
}
