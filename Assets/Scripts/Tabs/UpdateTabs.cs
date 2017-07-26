using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTabs : MonoBehaviour {
	void Awake(){
		Load.Setup();
		Save.Setup();
	}

	void Update () {
		if(Variables.changed){
			if(Variables.activeTab == 0){
				GameObject [] players = GameObject.FindGameObjectsWithTag("Zawodnik");		
				if(players.Length == Variables.players.Count){
					UpdateChanges(players);
					Variables.changed = false;
				}
			} else {
				GameObject [] clubs = GameObject.FindGameObjectsWithTag("Klub");
				if(Variables.clubs.Count == clubs.Length){
					for(int i = 0; i < Variables.clubs.Count; i++){
						clubs[i].GetComponent<SetCN>().SetName(Variables.clubs[i]);
					}
					Variables.changed = false;	
				}
			}
		}
	}

	public void UpdateChanges(GameObject [] players){
		Variables.players = Variables.players.OrderByDescending(order => order.score).ToList();
		
		for(int i = 0; i < Variables.players.Count; i++){
			players[i].GetComponent<ReadPlayer>().SetName(Variables.players[i].name);
			players[i].GetComponent<ReadPlayer>().SetClub(Variables.players[i].club);					
			players[i].GetComponent<ReadPlayer>().SetScore(Variables.players[i].score);	
		}
	}
}
