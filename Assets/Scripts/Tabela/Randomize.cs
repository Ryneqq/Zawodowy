using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Randomize {
	// Metoda pozwala na losowe ustawienie zawodników
	public static void RandPlayers(List<Player> players){

		int k = 2;

		for(int i = 0; i < Variables.range.Length; i++){
			// dla pierwszej połowy przedziału losujemy możliwość przestawienia
			for(int j = 0; j < Variables.range[i]/2; j++){
				if(k >= players.Count)
					return;
				// przestawamy na podstawie tablicy zasięgów
				int r = Random.Range(0, Variables.range[i] - j);
				Player temp = players[k];
				players[k] = players[k+r];
				players[k+r] = temp;
				k++;
			}
			k += Variables.range[i]/2;
		}
	}

	// Metoda robi rozpiskę turniejową w zależności od ilości zawodników
	public static int [] Order(int size){
		int count = size;
		int half = count/2;
		int [] tab = new int[count];
		tab[0] = 2;
		tab[1] = count - 1;
		tab[2] = half;
		tab[3] = half + 1;

		for(int i = 4; i < count - 3; i += 2){
			if(tab[i-2] == 4){
				tab[i+1] = 3;
				tab[i] = Mathf.Abs(tab[i+1] - count - 1) ;
				i+=2;
			}
			tab[i] = tab[i-2] - 2;
			tab[i+1] = Mathf.Abs(tab[i] - count - 1);
		}

		tab[count - 1] = 1;
		tab[count - 2] = count;
		// konwersja na indeksy
		for(int i = 0; i < tab.Length; i++){
			tab[i]--;
		}
		return tab;
	}

	// Metoda zwraca wielkość listy na podstawie tablicy możliwych wielkości
	// np. list.Count == 15, Size(list) == 16
	public static int Size(List<Player> players){
		int [] tab = {4,8,16,32,64};
		int i = 0;
		while(tab[i] < players.Count){
			i++;
		}
		return tab[i];
	}
}
