using UnityEngine;
using System.Collections;

public class LevelCamera : MonoBehaviour {

	public Spawner level;
	public Camera cam;
	public float speed = 1;

	// Use this for initialization
	void Start () {
		if (!cam)
			cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;
		var viewMouse = cam.ScreenToViewportPoint (Input.mousePosition);
		var camPos = cam.transform.position;
		var orthographicSizeHorizontal = cam.orthographicSize * cam.aspect;

		if(viewMouse.x < 0.1f){
			camPos -= Vector3.right*dt*speed;
		}else if(viewMouse.x > 0.9f){
			camPos += Vector3.right*dt*speed;
		}

		if (camPos.x > level.transform.position.x + level.LevelSize.x+orthographicSizeHorizontal
		    && camPos.x < level.LevelSize.width / 2 + level.transform.position.x-orthographicSizeHorizontal) {
			cam.transform.position = camPos;
		}

		var logger = Eventlogger.getInstance();
		logger.StartEvent("camPos");
		logger.WritePositon (cam.transform.position);
		logger.EndEvent();
	
	}
}
