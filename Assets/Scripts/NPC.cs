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
				}
			}
		}
	}

//	void OnCollisionEnter(Collision collision) {
	void OnTriggerEnter(Collider other) {
		if (isAlive) {
			GameObject player = other.gameObject;
			if (player.name.Equals("Robot Butler")) {
				Robot r = player.GetComponent<Robot>();
				Talk(r);
				TakeItem(r);
			}
		} else {
			GameObject dialogueText = GameObject.Find("Dialogue Text");
			Text t = dialogueText.GetComponent<Text>();
			t.text = "It's dead... What do you think it's going to say?";
		}
	}

	public bool IsAlive() {
		return isAlive;
	}
}
