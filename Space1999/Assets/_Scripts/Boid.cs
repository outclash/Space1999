using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {

	public Vector3 force = Vector3.zero;
	public Vector3 acceleration = Vector3.zero;
	public Vector3 velocity = Vector3.zero;
	public float mass = 1f;
	public float maximumSpeed = 10f;

	private List<SteeringBehaviours> steeringBehaviours = new List<SteeringBehaviours>();
	void Awake () {
		SteeringBehaviours[] sbs = GetComponents<SteeringBehaviours> ();
		foreach (SteeringBehaviours s in sbs) {
			steeringBehaviours.Add (s);
		}
	}

	public Vector3 Calculate(){
		force = Vector3.zero;

		foreach (SteeringBehaviours s in steeringBehaviours) {
			if (s.isActiveAndEnabled) {
				force = s.Calculate ();
			}
		}
		return force;
	}

	public Vector3 Seek(Vector3 target){
		Vector3 desire = target - transform.position;
		desire.Normalize ();
		desire *= maximumSpeed;
		return desire - velocity;
	}

	public Vector3 Arrive(Vector3 target, float slow, float dec){
		Vector3 targ = target - transform.position;
		float dist = targ.magnitude;
		if (dist == 0) {
			return velocity = Vector3.zero;
		}
		float ramp = maximumSpeed * (dist / (dec * slow));
		float clamp = Mathf.Min (ramp, maximumSpeed);
		Vector3 desire = clamp * (targ / dist);
		return desire - velocity;
	}

	void Update () {
		force = Calculate ();
		Vector3 newAcce = force / mass;
		float smoothRate = Mathf.Clamp(Time.deltaTime*9.0f,0.15f,0.4f)/2.0f;
		acceleration = Vector3.Lerp (acceleration, newAcce, smoothRate);
		velocity += acceleration * Time.deltaTime;
		transform.position += velocity * Time.deltaTime;
	}
}
