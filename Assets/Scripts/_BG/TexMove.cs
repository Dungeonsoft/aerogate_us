using UnityEngine;
using System.Collections;

public class TexMove : MonoBehaviour 
{
	public float speed = 1;

	// Update is called once per frame
	void Update () 
	{
		renderer.material.mainTextureOffset += new Vector2(0, (-0.03f*Time.deltaTime)*speed);
	}
}
