using UnityEngine;

public class DeletePlayer : MonoBehaviour {
	public void Clicked(){

		string num = GetComponent<SetText>().t.text;
		int index = Variables.ParseString(num) - 1;

		Destroy(this.gameObject);
		// usuń tego zawodnika z listy zawodników
		Variables.players.RemoveRange(index, 1);
		
		// usun wszystkich zawodników do tego momentu
		var zawodnicy = GameObject.FindGameObjectsWithTag("Zawodnik");
		foreach(var z in zawodnicy){
			string s = z.GetComponent<SetText>().t.text;
			if(Variables.ParseString(s) - 1 > index){
				Destroy(z.gameObject);
			}
		}
		// i dodaj ich na nowo (UI)
		GameObject.FindGameObjectWithTag("ZawodnicyContent").GetComponent<AddPlayer>().ReAdd(index, "Zawodnik");
		// dodaj listę opcji z klubami
		GameObject.FindGameObjectWithTag("ZawodnicyContent").GetComponent<AddPlayer>().UpdateDropdown();
		// wyswietl zawodników
		Variables.changed = true;
		// zaktualizuj bazę danych
		Variables.ToDatabase(Variables.playersFileName);
	}
}
