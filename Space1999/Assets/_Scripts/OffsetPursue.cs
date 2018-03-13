using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPursue : SteeringBehaviours {

	public Boid b;
	public Vector3 offset;
	public Vector3 worldTarget;
	void Start () {
		offset = transform.position - b.transform.position;
		//offset = Quaternion.Inverse (b.transform.position) * offset;
	}


	public override Vector3 Calculate ()
	{
		worldTarget = b.transform.TransformPoint (offset);
		float dist = Vector3.Distance (b.transform.position, transform.position);
		float time = dist / b.maximumSpeed;
		Vector3 tg = worldTarget + (time * b.velocity);
		return b.Seek (tg);
	}
}
