using UnityEngine;
using System.Collections;

public class ShieldUvMoveScript : MonoBehaviour {

    float offsetX;
	// Use this for initialization
	void Start () {

        offsetX = 0;
	}
	
	// Update is called once per frame
	void Update () {

        renderer.material.mainTextureOffset = new Vector2(0, offsetX);
        offsetX += Time.deltaTime;
	}
}
