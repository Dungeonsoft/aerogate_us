using UnityEngine;
using System.Collections;

public class DataStrTest : MonoBehaviour {

	// Use this for initialization
	Transform m_this;
	public GameObject insTest;
    public int vv = 10;
	void Start ()
	{
	    m_this = transform ;
		for(int i=0;i<vv;i++)
		{
			GameObject go = Instantiate(insTest , new Vector3(0,0,0) , Quaternion.identity) as GameObject;
//			GameObject go= GameObject.CreatePrimitive (PrimitiveType.Cube);
		    go.name ="cudTest"+i;
			go.tag ="bullet";
//			go.AddComponent("TestScript02");
			go.transform.parent= m_this;
		}
		
		
		for(int i=0; i<m_this.GetChildCount();i++)
		{
		     Transform  tr= m_this.GetChild(i);
			 Debug.Log ("Name:"+tr.name);
		}
		
		 GameObject[] ds= GameObject.FindGameObjectsWithTag("bullet"); 
		for(int i = 0 ;i<ds.Length;i++)
		{
		   	
			
		}
	}
	

}
