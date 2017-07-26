using UnityEngine;
using UnityEngine.UI;

public class SelectedTab : MonoBehaviour {

private Color selected;
private Color not;
public Image ZawodnicyTab;
public Image KlubyTab;

	void Start () {
		selected = ZawodnicyTab.color;
		not = KlubyTab.color;
	}

	public void ZawodnicySelected(){
		ZawodnicyTab.color = selected;
		KlubyTab.color = not;
		Variables.activeTab = 0;
	}

	public void KlubySelected(){
		KlubyTab.color = selected;
		ZawodnicyTab.color = not;
		Variables.activeTab = 1;
	}
}
