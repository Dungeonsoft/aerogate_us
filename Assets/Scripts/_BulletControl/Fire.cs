using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour 
{
	public Vector3 spawnPosition;

    void Awake()
    {
        spawnPosition = transform.localPosition;
        GetComponent<BoxCollider>().size = transform.GetChild(0).localScale;
    }
	void Update () 
	{
		transform.Translate(0,0,120*Time.deltaTime);
	}
	
	public void Activate()
	{
        transform.localPosition = spawnPosition;
	}
}
