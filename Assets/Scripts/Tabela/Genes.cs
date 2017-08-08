using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genes {

	private List<Player> DNA;
	private int fit;
	private float mutation = 0.01f;

	public Genes(){
		DNA = new List<Player>();
		fit = 0;
	}
	public Genes(List<Player> players){
		Replicate(players, Variables.range);
		CalculateFitness();
	}

	public Genes(Genes gene){
		Replicate(gene.GetDNA(), Variables.range);
		CalculateFitness();
	}

	public List<Player> Replicate(List<Player> players, int[] range){
		DNA = new List<Player>();
		DNA.Add(players[0]);
		DNA.Add(players[1]);		

		for (int i = 2; i < players.Count; i++){
			if(Random.Range(0f, 1f) < mutation){
				int s = 2; // suma zasięgów
				for (int j = 0; s <= i; j++){
					s += range[j];
				}
				s = s - i;

				if(s > 0){
					int ind = Random.Range(0,s);
					Player temp = players[i];
					players[i] = players[i + ind];
					players[i + ind] = temp;
				}
			}
			DNA.Add(players[i]);	
		}
		return DNA;
	}

	public int CalculateFitness(){
		if(DNA.Count == 0){
			return -1;
		}
		int[] tab = Randomize.Order(DNA.Count);
		fit = DNA.Count;
		for (int i = 0; i < DNA.Count; i+=2){
			if(DNA[i].club != "Klub" && DNA[tab[i]].club == DNA[tab[i+1]].club){
				fit--;
			}
		}
		// Debug.Log("fitness " + fit);					
		return fit;
	}

	public int Fitness(){
		return fit;
	}

	public List<Player> GetDNA(){
		return DNA;
	}
}
