using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Puzzle : MonoBehaviour {

	public List<DragTarget> targets;

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
			SceneManager.LoadScene("House");
			if (isCorrect) {
				Debug.Log("Puzzle is correct!");
			} else {
				Debug.Log("Puzzle is incorrect...");
			}
		}
	}
}
