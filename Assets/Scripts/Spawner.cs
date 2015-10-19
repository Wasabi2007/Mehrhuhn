using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {


	public struct Spawninfo{
		float scaling = 1;
		float points = 10;
		float spawnChancePerSecond = 0.25f;

	}

	public Camera cam;
	public float width;

	public Spawninfo[] layer;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
