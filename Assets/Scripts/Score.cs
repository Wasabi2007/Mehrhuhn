using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Score : MonoBehaviour {

	public Text Scorelabel;
	public int score = 0;


	// Use this for initialization
	void Start () {
		Scorelabel.text = string.Format("{0}",score);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDestroy(){
		PlayerPrefs.SetInt ("Score", score);
	}

	void addScore(int toadd){
		score += toadd;
		Scorelabel.text = string.Format("{0}",score);
	}
}
