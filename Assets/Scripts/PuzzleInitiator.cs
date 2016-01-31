using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PuzzleInitiator : Clickable {

	public string puzzleSceneName;
	public bool puzzleDone;
	public string puzzleTextName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (!puzzleDone) {
			if (other.name.Equals("Robot Butler")) {
				puzzleDone = true;
				GameObject.Find(puzzleTextName).GetComponent<Text>().enabled = true;
				GameObject puzzle = GameObject.Find(puzzleSceneName);
				Globals.cameraPosition = Camera.main.transform.position;
				Camera.main.transform.position = new Vector3(puzzle.transform.position.x + 1.0f, puzzle.transform.position.y, puzzle.transform.position.z - 7.0f);
				Camera.main.orthographic = true;
				Globals.cameraRotation = Camera.main.transform.localEulerAngles;
				Camera.main.transform.localEulerAngles = Vector3.zero;
//				SceneManager.LoadScene(puzzleSceneName);
			}
		}
	}
}
