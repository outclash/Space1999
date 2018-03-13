using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SteeringBehaviours : MonoBehaviour {

	private Boid boid;

	void Start () {
		boid = GetComponent<Boid> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public abstract Vector3 Calculate ();
}
