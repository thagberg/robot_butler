using UnityEngine;
using System.Collections;

public class DragTarget : MonoBehaviour {

	public bool done = false;
	public bool correct = false;
	public string correctDraggable;

	private bool inside = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		inside = true;
		Debug.Log("Enter: " + other.name);
	}

	void OnTriggerExit(Collider other) {
		inside = false;
		Debug.Log("Exit: " + other.name);
	}

	public void close(GameObject closer) {
		if (inside) {
			Draggable t = closer.GetComponent<Draggable>();
			if (t != null) {
				t.deactivate();
				done = true;
				closer.transform.position = new Vector3(gameObject.transform.position.x, 
													    gameObject.transform.position.y, 
														closer.transform.position.z);
				if (closer.name.Equals(correctDraggable)) {
					correct = true;
					Debug.Log("Dragged correct object!");
				}
			}
		}
	}
}
