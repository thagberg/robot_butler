using UnityEngine;
using System.Collections;

public class Dialogue : MonoBehaviour{

	public string defaultLine;
	public string specialLine;
	public string itemToFind;

	public Dialogue(string defaultLine, string specialLine, string itemToFind) {
		this.defaultLine = defaultLine;
		this.specialLine = specialLine;
		this.itemToFind = itemToFind;
	}

	public string getDialogue(Robot r) {
		// TODO: look through robot's inventory
		//		 and return the special line if 
		//		 the itemToFind is there
		if (itemToFind != null && !itemToFind.Equals("") && r.holdingObjectName.Equals(itemToFind)) {
			return specialLine;
		} else {
			return defaultLine;
		}
	}
}
