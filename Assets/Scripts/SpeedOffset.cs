using UnityEngine;
using System.Collections;

public class SpeedOffset : MonoBehaviour {
	public float offset;
	public float speed = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		renderer.material.SetTextureOffset ("_MainTex" , new Vector2(offset,0));
		offset = offset - Time.deltaTime*speed;
	}
}
