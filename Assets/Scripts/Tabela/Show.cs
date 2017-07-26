using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show : MonoBehaviour {

	public List<GameObject> _4;
	public List<GameObject> _8;
	public List<GameObject> _16;
	public List<GameObject> _32;

	void Start () {
		// instantine objekty z listy
		// stworz tyle guzikow do zmieniania stron ile jest obiektów w liscie

		List<Player> best = FindBest();
		int[] tab = Randomize.Order(best.Count);
		for(int i = 0; i < best.Count; i+=2){
			print(best[tab[i]].name+ " vs " + best[tab[i+1]].name);
		}
	}
	// Metoda ma za zadanie znalezienie jak najlepszego ustawienia zawodników,
	// tak by Ci nie mogli grać z kolegami z tego samego klubu, 
	// albo by ten proceder był możliwie jak najrzadszy.
	public List<Player> FindBest(){
		int popsize = 100; // wielkość populacji
		int generations = 20; // liczba generacji
		Genes best = new Genes();	// najlepsze możliwe rozlosowanie		
		List<Player> players = Variables.players; // lokalna referencja do zawodników
		List<Genes> population = new List<Genes>();	// populacja rozlosowań

		// stworzenie populacji
		for (int i = 0; i < popsize; i++){
			Randomize.RandPlayers(players);
			population.Add(new Genes(players));
		}
		for (int i = 0; i < generations; i++){
			// wyszukiwanie najlepszych genów	
			List<Genes> old = new List<Genes>(); // Lista genów do reprodukcji
			int fit = population[0].Fitness(); //losowy początkowy wskaźnik
			// wybranie genów do reprodukcji
			foreach (var p in population){
				if(fit <= p.Fitness()){
					old.Add(p);
					fit = p.Fitness();
				}
			}
			int count = old.Count; // liczba starych osobników gotowych do reprodukcji
			// dodane jako ostatnie ma mozliwie najlepszy fittness z całej populacji
			if(old[count-1].Fitness() > best.Fitness()){
				best = old[count-1];	// pobranie najlepszego dna z populacji				
			}
			// lepszego ustawienia nie da się zrobić
			if(old[count-1].Fitness() == best.GetDNA().Count){
				print("tutaj jestem");
				return best.GetDNA();
			}
			print("best fitness: " + old[count-1].Fitness());
			// selekcja naturalna - zabicie poprzedniej generacji
			population = new List<Genes>();
			// replikacja dna obiektów z poprzedniej generacji
			for(int j = 0; j < popsize; j++){
				int who = Random.Range(0, count); // ten który da geny do replikacji
				population.Add(new Genes(old[who]));
			}
		}
		return best.GetDNA();		
	}
	 // po instatnitine wylosuj zawodnikow i wpisz ich w tabele
}
