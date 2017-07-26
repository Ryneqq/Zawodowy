using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadPlayer : MonoBehaviour {
	public GameObject num;
	public GameObject _name;
	public GameObject club;
	public GameObject score;

	public int GetIndex(){
		return Variables.ParseString(num.GetComponent<Text>().text) - 1;
	}
	public void ReadName(string s){
		int index = GetIndex();
		Variables.players[index].name = _name.GetComponent<InputField>().text;
		Variables.ToDatabase(Variables.playersFileName);		
	}
	public void SetName(string s){
		_name.GetComponent<InputField>().text = s;
	}

	public void ReadClub(int i){
		int index = GetIndex();
		int value = club.GetComponent<Dropdown>().value;
		var options = club.GetComponent<Dropdown>().options;
		Variables.players[index].club = options[value].text;
		Variables.ToDatabase(Variables.playersFileName);
	}

	public void SetClub(string s){
		var options = club.GetComponent<Dropdown>().options;
		int i = 0;
		foreach(var o in options){
			if(o.text == s){
				club.GetComponent<Dropdown>().value = i;
				return;
			}
			i++;
		}
	}

	public void ReadScore(string s){
		int index = GetIndex();
		string sc = score.GetComponent<InputField>().text;
		int.TryParse(sc, out Variables.players[index].score);
		Variables.changed = true;
		Variables.ToDatabase(Variables.playersFileName);		
	}

	public void SetScore(int i){
		string s = i.ToString();
		score.GetComponent<InputField>().text = s;
	}
}
