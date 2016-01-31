using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour {

	public bool dragging = true;
	public bool canDrag = true;

	private GameObject collidingWith;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (dragging) {
			Vector3 mousePos = Input.mousePosition;
			mousePos.z = gameObject.transform.position.z;
			mousePos = Camera.main.ScreenToWorldPoint(mousePos);
			gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, gameObject.transform.position.z);
		}
	}

	void OnMouseDown() {
		if (canDrag) {
			dragging = true;
		}
	}

	void OnMouseUp() {
		if (canDrag) {
			dragging = false;
			if (collidingWith != null) {
				DragTarget t = collidingWith.GetComponent<DragTarget>();
				if (t != null) {
					t.close(gameObject);
				}
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (canDrag) {
			collidingWith = other.gameObject;
		}
	}

	void OnTriggerExit(Collider other) {
		if (canDrag) {
			collidingWith = null;
		}
	}

	public void deactivate() {
		canDrag = false;	
	}
}
