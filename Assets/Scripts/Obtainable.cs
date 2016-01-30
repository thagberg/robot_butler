using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Obtainable : Clickable {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		GameObject robot = other.gameObject;
		if (robot.name.Equals("Robot Butler")) {
			Robot r = robot.GetComponent<Robot>();
			GameObject dialogueText = GameObject.Find("Dialogue Text");
			Text t = dialogueText.GetComponent<Text>();
			if (r.holdingObjectName == null || r.holdingObjectName.Equals("")) {
				r.holdingObjectName = gameObject.name;
				t.text = "Oh... great... I've got a " + gameObject.name;
			} else {
				t.text = "*Sigh*  I can only hold _so_ many items, I'm afraid...";
			}
		}
	}
}
