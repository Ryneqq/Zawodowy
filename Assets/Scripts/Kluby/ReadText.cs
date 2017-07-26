using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadText : MonoBehaviour {
	public InputField namesField;
	public string text;
	public void ReadName(string s){
		text = namesField.text;
	}
}
