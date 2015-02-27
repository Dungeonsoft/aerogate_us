using UnityEngine;
using System.Collections;

public class LevelChangePlanShowHide : MonoBehaviour {

	float alphalTime = 0;
	float timer = 0;
	bool isAct = false;

	public float  stayTime = 4f;

    public GameObject[] beamMatObj;

	// Use this for initialization
	void Start () {
		renderer.material.SetColor("_TintColor" , new Color (1 , 1 , 1 , 0) );
	}
	
	// Update is called once per frame
    void Update()
    {
        if (!isAct) return;
        timer += Time.deltaTime;

        if (timer < stayTime)
        {
            alphalTime += Time.deltaTime * 0.5f;
            renderer.material.SetColor("_TintColor", new Color(1, 1, 1, alphalTime));

            if (alphalTime > 0.7f)
            {
                alphalTime = 0.7f;
            }
        }
        else
        {
            alphalTime -= Time.deltaTime * 0.5f;
            renderer.material.SetColor("_TintColor", new Color(1, 1, 1, alphalTime));
            if (alphalTime <= 0)
            {
                isAct = false;
                gameObject.SetActive(false);
            }
        }

        foreach (var Go in beamMatObj)
        {
            Go.renderer.material.SetColor("_TintColor", new Color(1, 1, 1,(1-alphalTime))*0.5f);
        }
    }

	public void Activate ()
	{
		alphalTime = 0;
		timer = 0;
		isAct = true;
	}

}
