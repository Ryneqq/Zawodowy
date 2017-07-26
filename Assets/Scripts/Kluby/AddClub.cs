using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddClub : AddContent {

	public GameObject popUp;
	public ReadText read;

	void Awake () {
		pos = gameObject.GetComponent<RectTransform>().rect.height/2 - delta;
		Variables.clubs = new List<string>();
		Load.Setup();
		
		if(Load.Check(Variables.clubFileName)){
			string content = Load.Read(Variables.clubFileName);
			Variables.clubs = Load.StringToList(content);
			AddLoaded();
		}
	}

	// Metoda wywoływana kliknięciem guzika 'Dodaj' w menu 'DodajKlub'
	public void Clicked(){
		// jezeli nie ma wartosci w input field, nie pozwol na dodanie klubu
		if(read.text != string.Empty && index < 99){
			foreach(var c in Variables.clubs){
				if(read.text == c){
					// dodaj komunikat, że nie można dodać klubów o takiej samej nazwie
					return; 
				}
			}
			Variables.clubs.Add(read.text);
			GameObject temp = Add(index, pos);
			temp.GetComponent<SetCN>().SetName(read.text);
			index++;
			pos -= delta;

			float h = gameObject.GetComponent<RectTransform>().rect.height;
			if(index * delta > h){
				Resize(h, "Klub");
			}
		}
		popUp.SetActive(false);
		Variables.ToDatabase(Variables.clubFileName);
	}

	// Metoda dodaje wczytane z pliku kluby do zakładki 'Kluby'
	public void AddLoaded(){
		// float h = gameObject.GetComponent<RectTransform>().rect.height;		

		foreach(var c in Variables.clubs){
			GameObject temp = Add(index, pos);
			temp.GetComponent<SetCN>().SetName(c);
			index++;
			pos -= delta;

			// if(index * delta > h){
			// 	Resize(h, "Klub");
			// 	h = gameObject.GetComponent<RectTransform>().rect.height;				
			// }
		}
		// GameObject [] clubs = GameObject.FindGameObjectsWithTag("Klub");
		// for(int i = 0; i < Variables.clubs.Count; i++){
		// 	clubs[i].GetComponent<SetCN>().SetName(Variables.clubs[i]);
		// }
		// Variables.changed = false;	
	
	}
}
