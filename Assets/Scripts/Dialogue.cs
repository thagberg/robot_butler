using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dialogue : MonoBehaviour{

	public Dictionary<string, Dictionary<string, string>> lines;

	public Dialogue() {
		lines = new Dictionary<string, Dictionary<string, string>>();

		lines.Add("Lazy Father", new Dictionary<string, string>());
		lines["Lazy Father"].Add("", "*BURP* Hey! Joffrey! Get me somethin' to read!");
		lines["Lazy Father"].Add("DirtyMagazine", "*Wheeze* Hmmm... That looks good...");
		lines["Lazy Father"].Add("ScholarlyBook", "*Hack hack* What am I supposed to do with this garbage?!");

		lines.Add("Lazy Mother", new Dictionary<string, string>());
		lines["Lazy Mother"].Add("", "I have nothing to say.");

		lines.Add("Lazy Child", new Dictionary<string, string>());
		lines["Lazy Child"].Add("", "I have nothing to say.");
	}

	public string getDialogue(string name, Robot r) {
		if (lines.ContainsKey(name)) {
			Dictionary<string, string> lookup = lines[name];
			if (lookup.ContainsKey(r.holdingObjectName)) {
				return lookup[r.holdingObjectName];
			} else {
				return lookup[""];
			}
		}
		return "";
	}
}
