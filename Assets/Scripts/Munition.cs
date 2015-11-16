using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Munition : MonoBehaviour {

	public int maxMunition = 7;
	public int currentMunition = 7;
	public float reloadTime = 1;

	private float munitionUsedTime;
	public bool munitionState = true;
	public Text label;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!munitionState && munitionUsedTime < Time.time - reloadTime) {
			currentMunition = maxMunition;
			munitionState = true;
			//Debug.Log("reloaded");
		}

		if (Input.GetMouseButtonDown (0) && munitionState) {
			currentMunition--;
			//Debug.Log("currentMunition: "+currentMunition);
			if(currentMunition < 0){
				munitionUsedTime = Time.time;
				munitionState = false;
				var logger = Eventlogger.getInstance();
				logger.StartEvent("relode_lmb");
				logger.EndEvent();
				//Debug.Log("reloading");				
			}
		}


		if (Input.GetMouseButtonDown (1) && munitionState) {
			currentMunition = 0;
			munitionUsedTime = Time.time;
			munitionState = false;
			//Debug.Log("reloading");
			var logger = Eventlogger.getInstance();
			logger.StartEvent("relode_rmb");
			logger.Writer.WriteElementString("currentMunition",currentMunition.ToString());
			logger.EndEvent();
		}

		label.text = Mathf.Max (0, currentMunition) + "/" + maxMunition + (!munitionState?" R":"");
	
	}

}
