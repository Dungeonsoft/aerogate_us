using UnityEngine;
using System.Collections;


//충돌여부를 관장하는 스크립트.
public class UnbeatableScript : MonoBehaviour 
{
	//float lTime = 10f;  //원래 10초.
	bool isUnbeatable = true;
    GameObject PC;

	GameObject runeFx;
	RuneAlphaAni runeAlphaAni;
	// Use this for initialization

    public GameObject[] childObject;

    void Awake()
    {
        PC = GameObject.Find("PC");
    }

    void Start()
    {
        //runeFx = GameObject.Find("GameManager").transform.FindChild("Rune").gameObject;
        //runeAlphaAni = runeFx.GetComponent<RuneAlphaAni>();
        
        //PC.tag = "Unbeatable";
        //StartCoroutine(Twinkle());
        //runeFx.SetActive(true);
    }
	
	// Update is called once per frame
    //void Update()
    //{
    //    if (isUnbeatable)
    //    {
    //        this.renderer.enabled = !this.renderer.enabled;
    //    }
    //    else
    //        this.renderer.enabled = true;
    //}

    public void UnbeatableStart(float limitTime)
    {
        isUnbeatable = true;
        //Debug.Log("UnBeatable!!!!!!");
        StartCoroutine(Twinkle());
        if(PC.tag != "SuperPower")      PC.tag = "Unbeatable";
        //runeFx.SetActive(true);

        StartCoroutine(TwinkleEndTime(limitTime));
    }

    IEnumerator Twinkle()
    {
        while (isUnbeatable)
        {
            //Debug.Log("Twinkle Twinkle!!");
            //Debug.Log("Object Name is " + name);
            this.renderer.enabled = !this.renderer.enabled;
            foreach (var child in childObject)
            {
                child.renderer.enabled = !child.renderer.enabled;
            }
            yield return null;
        }

        this.renderer.enabled = true;
        foreach (var child in childObject)
        {
            child.renderer.enabled = true;
        }
    }


    public IEnumerator TwinkleEndTime(float limitTime = 5f)
    {
        //Debug.Log("IN TwinkleEndTime!!!");
        //runeAlphaAni.Activate(limitTime - 2f);
        yield return new WaitForSeconds(limitTime);
        isUnbeatable = false;
        if (PC.tag != "SuperPower")     PC.tag = "Player";
    }
}
