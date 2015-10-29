﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D),typeof(BoxCollider2D))]
public class Mehrhuhn : MonoBehaviour {

	public int points = 100;
	public float speed = 1;
	public bool goXPositiv = true;
	public float targetHeight = 0;

	public float maxX = 300;

	public float lifeTime = -1;

	private float xDirection = 1;

	private Rigidbody2D rigid2d;

	// Use this for initialization
	void Start () {
		rigid2d = GetComponent<Rigidbody2D> ();
		rigid2d.isKinematic = true;

		xDirection = (goXPositiv ? 1 : -1);
	}
	
	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;
		xDirection = (goXPositiv ? 1 : -1);

		rigid2d.position += Vector2.right * xDirection * speed*dt;
		if (rigid2d.position.y < targetHeight && lifeTime > 0 ) {
			rigid2d.position += Vector2.up * speed * dt;
		}

		if (lifeTime < 0) {
			rigid2d.position -= Vector2.up * speed * dt;
		}

		if (rigid2d.position.x > maxX) {
			MonoBehaviour.Destroy (this.gameObject);
		}

		lifeTime -= dt;

	}

	void OnMouseUp(){
		MonoBehaviour.Destroy (this.gameObject);
	}
}