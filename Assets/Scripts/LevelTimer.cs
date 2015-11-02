using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelTimer : MonoBehaviour {

	public int Minutes = 2;
	public int Seconds = 0;
	public Text lable;

	public int nextlevel = 2;

	private float time_ = 0;


	// Use this for initialization
	void Start () {
		time_ = Minutes * 60 + Seconds;
	}
	
	// Update is called once per frame
	void Update () {
		time_ -= Time.deltaTime;
		if (time_ <= 0) {
			Application.LoadLevel(nextlevel);
		}

		lable.text = string.Format ("{0:00}:{1:00}", Mathf.FloorToInt(time_ / 60), time_ % 60);
	}
}
