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

				if (holdingObjectName.Equals(killItemName)) {
					isAlive = false;
				}
			}
		}
	}

//	void OnCollisionEnter(Collision collision) {
	void OnTriggerEnter(Collider other) {
		GameObject player = other.gameObject;
		if (player.name.Equals("Robot Butler")) {
			Robot r = player.GetComponent<Robot>();
			Talk(r);
			TakeItem(r);
		}
	}

	public bool IsAlive() {
		return isAlive;
	}
}
