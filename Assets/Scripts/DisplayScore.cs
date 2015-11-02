using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class DisplayScore : MonoBehaviour {

	private Text lable;
	// Use this for initialization
	void Start () {
		lable = GetComponent<Text> ();
		lable.text = "Score: "+PlayerPrefs.GetInt ("Score", 0);
	}

}
