using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Obiekt przygotowuje liste zawodników do rozlosowania
public class Clean : MonoBehaviour {

	void Start () {
		Camera.main.GetComponent<ChangeScene>().SetRes("tab");
		DeleteEmpty(Variables.players);
		int count = Randomize.Size(Variables.players);
		while(count > Variables.players.Count){
			Variables.players.Add(new Player());
		}
	}

	private List<Player> DeleteEmpty(List<Player> players){
		List<Player> p = new List<Player>();
		for(int i = 0; i < players.Count; i++){
			if(players[i].name != string.Empty){
				p.Add(players[i]);
			}
		}
		return p;
	}
}
