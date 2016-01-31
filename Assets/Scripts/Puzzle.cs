using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Puzzle : MonoBehaviour {

	public List<DragTarget> targets;
	public string successItemName;
	public string failureItemName;
	public string puzzleTextName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bool isDone = true;
		bool isCorrect = true;
		foreach(DragTarget t in targets) {
			if (!t.done) {
				isDone = false;
				break;
			} else if(!t.correct) {
				isCorrect = false;
			}
		}

		if (isDone) {
			Camera.main.transform.position = Globals.cameraPosition;
			Camera.main.transform.localEulerAngles = Globals.cameraRotation;
			Camera.main.orthographic = false;
			GameObject.Find(puzzleTextName).GetComponent<Text>().enabled = false;
			if (isCorrect) {
				Debug.Log("Puzzle is correct!");
				GameObject robotObject = GameObject.Find("Robot Butler");
				Robot t = robotObject.GetComponent<Robot>();
				t.holdingObjectName = successItemName;
			} else {
				Debug.Log("Puzzle is incorrect...");
				GameObject robotObject = GameObject.Find("Robot Butler");
				Robot t = robotObject.GetComponent<Robot>();
				t.holdingObjectName = failureItemName;
			}
			this.enabled = false;
		}
	}
}
