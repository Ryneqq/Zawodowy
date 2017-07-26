using UnityEngine;

public class ToggleFullscreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.fullScreen = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("f")){
			Screen.fullScreen = !Screen.fullScreen;
		}
		if(Input.GetKeyDown("e")){
			Screen.SetResolution(1920,1080,true,60);
		}
		if(Input.GetKeyDown("q")){
			Screen.SetResolution(1240,900,false,60);
		}
		if(Input.GetKeyDown("s")){
			Application.CaptureScreenshot("Tabela32.png");
		}
	}
}
