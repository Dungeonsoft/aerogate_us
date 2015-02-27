using UnityEngine;
using System.Collections;

public class TestParticleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		ParticleSystem.Particle[] p = new ParticleSystem.Particle[particleSystem.particleCount+1];
		int l = particleSystem.GetParticles(p);

			Debug.Log ("p["+1+"].lifetime  ::: "+ p[1].lifetime);
			Debug.Log ("p["+1+"].GetType()  ::: "+ p[1].GetType());
//		p[1].GetType()

		}


}
