using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dialogue : MonoBehaviour{

	public Dictionary<string, Dictionary<string, string>> lines;

	public Dialogue() {
		lines = new Dictionary<string, Dictionary<string, string>>();

		lines.Add("Lazy Father", new Dictionary<string, string>());
		lines["Lazy Father"].Add("", "*BURP* Hey! Joffrey! Get me somethin' to read!");
		lines["Lazy Father"].Add("DirtyMagazine", "*Wheeze* Hmmm... That looks good...\n\nOH GOD!  MY HEART!  *GASP*");
		lines["Lazy Father"].Add("ScholarlyBook", "*Hack hack* What am I supposed to do with this garbage?!");

		lines.Add("Lazy Mother", new Dictionary<string, string>());
		lines["Lazy Mother"].Add("", "Joffrey, go fetch me some food.  I absolutely MUST eat this moment!");
		lines["Lazy Mother"].Add("RawChicken", "*nom nom nom*  Oooh!  I feel so fancy!\n\n*gurgle*  Ugh... I don't feel so good...");
		lines["Lazy Mother"].Add("CookedChicken", "Well, I guess this will _have_ to do...");

		lines.Add("Lazy Child", new Dictionary<string, string>());
		lines["Lazy Child"].Add("", "I'm booooooored Joffrey... Find me something to play with, NOW!");
		lines["Lazy Child"].Add("ActionFigure", "I'm BORED of playing with this toy!");
		lines["Lazy Child"].Add("Scissors", "Yay!  Mummy would never let me play with these!  Whee!\n\nOops! *SLICE*");
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
