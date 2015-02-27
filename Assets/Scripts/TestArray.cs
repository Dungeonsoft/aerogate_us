using UnityEngine;
using System.Collections;

public class TestArray : MonoBehaviour {

    public static string[][] characterSpeakScript;
    string[] test;

	// Use this for initialization
	void Start () {
characterSpeakScript[0] = new string[]{"dsfds","sdfda","sffs"};


        test = characterSpeakScript[0];
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
