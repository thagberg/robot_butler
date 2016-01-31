using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {
	
	private static BackgroundMusic instance = null;
	public static BackgroundMusic Instance {
		get { return instance; }
	}

	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		// The background music is assumed to be attached as an AudioSource.
		AudioSource bgMusic = GetComponent<AudioSource> ();
		bgMusic.Play ();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
