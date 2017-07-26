public class Player{
	public string name;
	public string club;
	public int score;

	public Player(){
		name = string.Empty;
		club = string.Empty;
		score = 0;
	}

	public Player(string _name, string _club, int _score){
		name = _name;
		club = _club;
		score = _score;
	}
}
