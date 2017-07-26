using UnityEngine;

public class DeleteClub : MonoBehaviour {
	// Metoda wywoływana guzikiem usuwania. Guziki te są zlokalizowane koło nazwy każdego klubu.
	public void Clicked(){

		string num = GetComponent<SetCN>().t.text; // którego z rzędu usuwam
		int index = Variables.ParseString(num) - 1;

		Destroy(this.gameObject);
		Variables.clubs.RemoveRange(index, 1);

		// usun wszystkich zawodników do tego momentu
		var clubs = GameObject.FindGameObjectsWithTag("Klub");
		foreach(var c in clubs){
			string s = c.GetComponent<SetCN>().t.text;
			if(Variables.ParseString(s) - 1 > index){
				Destroy(c.gameObject);
			}
		}
		// dodaj ich na nowo (UI) - ciało metody znajduje się w 'AddContent'
		GameObject.FindGameObjectWithTag("KlubyContent").GetComponent<AddClub>().ReAdd(index, "Klub");
		// zaktualizuj bazę danych
		Variables.changed = true;
		Variables.ToDatabase(Variables.clubFileName);
		
	}
}
