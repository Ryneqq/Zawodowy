using UnityEngine;

public class ChangeScene : MonoBehaviour {
	public void LoadProgram(){
		Application.LoadLevel("Program");
	}
	public void LoadTab(){	
		if(Variables.players.Count < 4){
			GameObject.FindGameObjectWithTag("Error").GetComponent<ErrorWindow>().ShowError(
				"Nie można załadować tabeli, \r\n ponieważ jest za mało zawodników."
				);
				return;
		}
		Application.LoadLevel("Tabela");
	}
	public void SetRes(string which){
		if(which == "tab"){
			Screen.SetResolution(1920,1080,true,60);		
		} else {
			Screen.SetResolution(1240,900,false,60);
		}
	}
}
