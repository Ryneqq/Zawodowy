using UnityEngine;
using UnityEngine.UI;

public class PopUpClub : MonoBehaviour {

	public GameObject popUp;  
	public GameObject inField;

	void Start () {
		popUp.SetActive(false);
	}

	public void Clicked(){
		inField.GetComponent<InputField>().text = string.Empty;		
		popUp.SetActive(true);
	}
	
	public void Canceled(){
		popUp.SetActive(false);
	}
}
