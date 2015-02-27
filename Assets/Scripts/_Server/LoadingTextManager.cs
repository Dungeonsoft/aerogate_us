using UnityEngine;
using System.Collections;

public class LoadingTextManager : MonoBehaviour {

    public int state = 0;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (state == 1)
        {
            gameObject.GetComponent<UILabel>().text = "파일럿 정보를 확인중입니다...";
            Debug.Log("파일럿 정보를 확인중입니다.");
        }
        if (state == 2)
        {
            gameObject.GetComponent<UILabel>().text = "기체의 상태를 확인중입니다...";
            Debug.Log("기체의 상태를 확인중입니다.");
        }
        if (state == 3)
        {
            gameObject.GetComponent<UILabel>().text = "격납고에 진입중입니다...";
            Debug.Log("격납고에 진입중입니다.");
        }
	}
}
