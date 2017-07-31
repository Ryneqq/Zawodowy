using UnityEngine;

public class ChangeScene : MonoBehaviour {
	public void LoadProgram(){
		Application.LoadLevel("Program");
	}
	public void LoadTab(){	
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
