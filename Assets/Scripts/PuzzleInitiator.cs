using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PuzzleInitiator : Clickable {

	public string puzzleSceneName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (!Globals.ovenPuzzleDone) {
			Globals.ovenPuzzleDone = true;
			if (other.name.Equals("Robot Butler")) {
				SceneManager.LoadScene(puzzleSceneName);
			}
		}
	}
}
