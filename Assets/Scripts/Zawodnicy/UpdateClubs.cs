using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateClubs : MonoBehaviour {

	public Dropdown d;

	public void UpdateClub(){
		d.options = new List<Dropdown.OptionData>();
		List <string> s = new List<string>();
		s.Add("Klub");
		d.AddOptions(s);
		d.AddOptions(Variables.clubs);
	}
}
