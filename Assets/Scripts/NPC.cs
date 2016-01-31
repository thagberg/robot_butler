using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NPC : Clickable {

	public Dialogue dialogue;
	public List<string> acceptedItems;
	public string holdingObjectName;
	public string killItemName;

	private bool isAlive = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Talk(Robot r) {
		GameObject dialogueText = GameObject.Find("Dialogue Text");
		Text t = dialogueText.GetComponent<Text>();
		t.text = dialogue.getDialogue(gameObject.name, r);
	}

	void TakeItem(Robot r) {
		foreach (string item in acceptedItems) {
			if (r.holdingObjectName.Equals(item)) {
				holdingObjectName = r.holdingObjectName;
				r.holdingObjectName = "";
				GameObject holdingObject = GameObject.Find(holdingObjectName);
				holdingObject.GetComponent<Obtainable>().used = true;

				if (holdingObjectName.Equals(killItemName)) {
					isAlive = false;
					gameObject.transform.Rotate(new Vector3(0.0f, 0.0f, -90.0f));  // FALL DOWN.
					r.IncrementNumCompletedTasks();
				} else {
					r.IncrementNumCompletedTasks();
				}
				Destroy(holdingObject); 
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		GameObject player = other.gameObject;
		Robot r;
		if (player.name.Equals("Robot Butler")) {
			r = player.GetComponent<Robot>();
		} else {
			return;
		}

		if (isAlive) {
			Talk(r);
			TakeItem(r);
		} else {
			GameObject dialogueText = GameObject.Find("Dialogue Text");
			Text t = dialogueText.GetComponent<Text>();
			t.text = "Dead, I'm afraid... let's move on.";
			TakeItem(r);
		}
	}

	public bool IsAlive() {
		return isAlive;
	}
}
