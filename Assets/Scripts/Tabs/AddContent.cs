using UnityEngine;

public class AddContent : MonoBehaviour {

	public GameObject UI;
	protected float pos;
	protected int index = 0;
	protected float delta = 50f;

	public void Resize(float h, string t){
		h += delta * 10; // dziesięć dodatkowych zawodników		
		gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0f, h);

		GameObject [] objects = GameObject.FindGameObjectsWithTag(t);
		foreach(var o in objects){
			Destroy(o.gameObject);
		}
		int count;
		if(t == "Klub"){
			count = Variables.clubs.Count;
		} else {
			count = Variables.players.Count;
		}
		for(index = 0, pos = h / 2 - delta; index <	count; index++, pos -= delta){
			Add(index, pos);
		}
		Variables.changed = true;
	}

	public void ReAdd(int i, string t){
		index--; 

		if(index == i){
			pos += delta;
			return;
		}

		for(; index > i; index--, pos += delta);

		pos += delta;
		Add(index,pos);
		index++;
		pos -= delta;

		int count;
		if(t == "Klub"){
			count = Variables.clubs.Count;
		} else {
			count = Variables.players.Count;
		}

		for(; index < count; index++, pos -= delta){
			Add(index, pos);
		}
	}

	public GameObject Add(int i, float y){
		GameObject temp = Instantiate(UI, new Vector3(0f, y, 0f), Quaternion.identity);
		temp.GetComponent<SetText>().Set((i + 1) + ".");
		temp.transform.SetParent(this.gameObject.transform,false);
		return temp;
	}

}
