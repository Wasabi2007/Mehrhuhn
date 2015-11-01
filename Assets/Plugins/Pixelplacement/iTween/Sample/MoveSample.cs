using UnityEngine;
using System.Collections;

public class MoveSample : MonoBehaviour
{	
	void Start(){
		iTween.MoveAdd(gameObject,Vector3.up*3,5);// iTween.Hash("y", 2, "easeType", "liniar", "loopType", "none"));
	}
}

