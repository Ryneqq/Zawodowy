using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorWindow : MonoBehaviour {
	public GameObject errorWindow;
	void Start () {
		errorWindow.SetActive(false);
	}
	public void ShowError(string s){
		errorWindow.SetActive(true);
		gameObject.GetComponent<SetText>().Set(s);
	}
	public void Clicked(){
		errorWindow.SetActive(false);
	}
}
