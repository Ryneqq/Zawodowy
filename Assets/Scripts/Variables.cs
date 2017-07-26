using System.Collections.Generic;
public static class Variables {
	public static List<Player> players;
	public static List<string> clubs;
	public static bool changed = false;
	public static int activeTab = 0;
    public static string playersFileName = "players.txt";
    public static string clubFileName = "clubs.txt";

	public static int[] range = {2, 4, 4, 4, 8, 8}; // byc moze zmienie sobie wszedzie na var
	
	public static int ParseString(string s){
		string sub = s.Substring(0,2);
		
		int i;
		if( int.TryParse(sub, out i) ){
			return i;
		}

		sub = s.Substring(0,1);
		return int.Parse(sub);
	}

	public static void ToDatabase(string which){
		if(which == playersFileName){
			List<string> playerString = new List<string>();
			foreach(var p in players){
				playerString.Add(p.name);
				playerString.Add(p.club);
				playerString.Add(p.score.ToString());
			}
			Save.Write(playerString, playersFileName);
		} else {
			Save.Write(clubs, clubFileName);
		}
	}
}
