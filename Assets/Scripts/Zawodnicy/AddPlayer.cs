using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayer : AddContent {

	void Start(){				
		pos = gameObject.GetComponent<RectTransform>().rect.height/2 - delta;
		Variables.players  = new List<Player>();
		if(Load.Check(Variables.playersFileName)){
			string content = Load.Read(Variables.playersFileName);
			List<string> players = Load.StringToList(content);
			for(int i=0; i < players.Count; i+=3){
				Player p = new Player(players[i], players[i+1], int.Parse(players[i+2]));
				Variables.players.Add(p);
			}
			AddLoaded();
			UpdateDropdown();
			Variables.changed = true;
		}
	}

	public void Clicked(){
		if (index > 31)
			return;
			
		Add(index, pos);
		pos -= delta;
		index++;
		
		Player player = new Player();
		Variables.players.Add(player);
		
		float h = gameObject.GetComponent<RectTransform>().rect.height;
		if(index * delta > h){
			Resize(h, "Zawodnik");
		}

		UpdateDropdown();
	}

	public void AddLoaded(){
		foreach(var p in Variables.players){
			Add(index, pos);
			index++;
			pos -= delta;
		}
	}

	public void UpdateDropdown(){
		GameObject [] gayObjects = GameObject.FindGameObjectsWithTag("Zawodnik");
		foreach(var g in gayObjects){
			g.GetComponent<UpdateClubs>().UpdateClub();
		}
	}
}
