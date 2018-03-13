using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : SteeringBehaviours {

	public Boid b;
	public GameObject tg;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public override Vector3 Calculate ()
	{
		return b.Arrive (tg.transform.position,15f,10f);
	}
}
