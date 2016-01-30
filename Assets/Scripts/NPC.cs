using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NPC : Clickable {

	public Dialogue dialogue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Talk(Robot r) {
		GameObject dialogueText = GameObject.Find("Dialogue Text");
		Text t = dialogueText.GetComponent<Text>();
		t.text = dialogue.getDialogue(r);
		//Debug.Log(dialogue.getDialogue(r));
	}

//	void OnCollisionEnter(Collision collision) {
	void OnTriggerEnter(Collider other) {
		GameObject player = other.gameObject;
		if (player.name.Equals("Robot Butler")) {
			Robot r = player.GetComponent<Robot>();
			Talk(r);
		}
	}
}
