using UnityEngine;
using System.Collections;

public class AddScoreLabelScript : MonoBehaviour 
{
		
	int sW;
	int sH;
	float propotion;
	
	GameObject UiRoot;
	
	void Awake ()
	{

		sW = Screen.width;
		sH = Screen.height;
		UiRoot = GameObject.Find ("UI Root (2D)");
		propotion = ((float)UiRoot.GetComponent<UIRoot>().manualHeight/sH);
//		propotion  = 800f/sH;
		sW = (int)(sW * propotion);
		sH = (int)(sH * propotion);
	}

	void Update () 
	{
		transform.Translate(0 , 0.1f*Time.deltaTime , 0);
		if(Time.timeScale != 0)
			GetComponent<TweenScale>().enabled =true;
		else
			GetComponent<TweenScale>().enabled =false;
	}

    public void Activate(GameObject target, int score, bool isPerfect)
    {
        gameObject.GetComponent<UILabel>().text = score.ToString();
        gameObject.GetComponent<UILabel>().MakePixelPerfect();
        //		Camera worldCam = NGUITools.FindCameraForLayer(target.layer);
        //		Camera guiCam = NGUITools.FindCameraForLayer(gameObject.layer);
        //		Vector3 pos = guiCam.ViewportToWorldPoint (worldCam.WorldToViewportPoint (target.transform.position));

        Vector3 pos = Camera.main.WorldToViewportPoint(target.transform.position);
        transform.localPosition = new Vector3((pos.x - 0.5f) * sW, (pos.y - 0.5f) * sH, 0);

        //		transform.localPosition = pos
        //			.position = pos;
        if (isPerfect)
        {
            transform.position += new Vector3(0, 0.1f, 0);
            transform.localScale = new Vector3(28, 28, 1);
            gameObject.GetComponent<TweenScale>().from = new Vector3(10, 10, 10);
            gameObject.GetComponent<TweenScale>().to = new Vector3(30, 30, 30);
            //gameObject.GetComponent<UILabel>().color = new Color(1f, 0f, 0f, 1f); //기존색깔.
            gameObject.GetComponent<UILabel>().color = new Color(135 / 255, 1, 125 / 255, 1f);  //수정색깔. 일반 파괴랑 같은 색으로 표시.

            gameObject.GetComponent<TweenAlpha>().duration = 0.6f;
            gameObject.GetComponent<TweenScale>().duration = 0.6f;
            gameObject.GetComponent<TweenScale>().method = TweenScale.Method.EaseOut;
            StartCoroutine(TimeOut(0.6f));

        }
        else
        {
            gameObject.GetComponent<TweenScale>().from = new Vector3(15, 15, 15);
            gameObject.GetComponent<TweenScale>().to = new Vector3(20, 20, 20);
            gameObject.GetComponent<UILabel>().color = new Color(135 / 255, 1, 125 / 255, 1f);
            
            gameObject.GetComponent<TweenAlpha>().duration = 0.3f;
            gameObject.GetComponent<TweenScale>().duration = 0.3f;
            gameObject.GetComponent<TweenScale>().method = TweenScale.Method.BounceIn;
            StartCoroutine(TimeOut(0.3f));
        }
    }

	IEnumerator TimeOut (float val)
	{
		yield return new WaitForSeconds(val);
		gameObject.SetActive(false);
	}
}
