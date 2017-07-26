using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {
	public void LoadProgram(){
		Application.LoadLevel("Program");
	}
	public void LoadTab(){
		Application.LoadLevel("Tabela");
	}
}
