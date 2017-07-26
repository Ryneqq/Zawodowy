using UnityEngine;
using UnityEngine.UI;

public class ChangingTabs : MonoBehaviour {
	private bool ZawodnicyTab = true;
	private bool KlubyTab = false;

	public GameObject ZawodnicyContent;
	public GameObject KlubyContent;
	

	void Start(){
		ZawodnicyContent.SetActive(true);
		KlubyContent.SetActive(false);
	}

	public void ZawodnicyTabClicked(){
		if(!ZawodnicyTab){
			ZawodnicyTab = true;
			KlubyTab = false;
			ZawodnicyContent.SetActive(true);
			KlubyContent.SetActive(false);
			gameObject.GetComponent<SelectedTab>().ZawodnicySelected();
			UpdateDropdown();
		}
	}

	public void KlubyTabClicked(){
		if(!KlubyTab){
			KlubyTab = true;
			ZawodnicyTab = false;
			KlubyContent.SetActive(true);
			ZawodnicyContent.SetActive(false);
			gameObject.GetComponent<SelectedTab>().KlubySelected();
		}
	}

	private void UpdateDropdown(){
		GameObject [] gayObjects = GameObject.FindGameObjectsWithTag("Zawodnik");
		foreach(var g in gayObjects){
			g.GetComponent<UpdateClubs>().UpdateClub();
		}
	}
}
