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
		lines["Lazy Mother"].Add("", "Joffrey, go fetch me some food.  I absolutely MUST eat this instant!");
		lines["Lazy Mother"].Add("RawChicken", "*nom nom nom*  Oooh!  I feel so fancy!\n\n*gurgle*  Ugh... I don't feel so good...");
		lines["Lazy Mother"].Add("CookedChicken", "Well, I guess this will _have_ to do...");

		lines.Add("Lazy Child", new Dictionary<string, string>());
		lines["Lazy Child"].Add("", "I'm booooooored Joffrey... Find me something to play with, NOW!");
		lines["Lazy Child"].Add("ActionFigure", "I'm BORED of playing with this toy!");
		lines["Lazy Child"].Add("Scissors", "Yay!  Mummy would never let me play with these!  Whee!\n\nOops! *SLICE*");

		lines.Add("TV", new Dictionary<string, string>());
		lines["TV"].Add("", "It's the master's television set...\n$0 down payment with 30% APR interest...\nWhat a _great_ deal...");

		lines.Add("Couch", new Dictionary<string, string>());
		lines["Couch"].Add("", "The family sofa...\nAfter months of 'stress testing',\nit has developed a permanent imprint\nof the master's buttocks...");

		lines.Add("Desk", new Dictionary<string, string>());
		lines["Desk"].Add("", "Ahh... the desk. A great instrument for study, research, and\nthe exploration of literature and the arts.\nI think it got used, once...");

		lines.Add("Stove", new Dictionary<string, string>());
		lines["Stove"].Add("", "The one time the missus used the stove, Augustus was set on fire\nand I nearly melted my motherboard trying\nto control the flames...");

		lines.Add("Sandbox", new Dictionary<string, string>());
		lines["Sandbox"].Add("", "Augustus's sandbox... I caught him burying his feces in here, once...");
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
