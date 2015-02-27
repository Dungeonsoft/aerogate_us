using UnityEngine;
using System.Collections;

public class FxLifeScript : MonoBehaviour 
{
	public bool isFrame = false;
	public float isLifeTime = 1.5f;
	public int LifeFrame = 4;


    public void OnEnable()
    {
        if (transform.FindChild("Plane1X1") != null)
            transform.FindChild("Plane1X1").renderer.material.mainTextureOffset = new Vector2(0, 0);

        if (!isFrame) StartCoroutine(UnActive());
    }

    IEnumerator UnActive()
    {
        //Debug.Log("UnAct");
        yield return new WaitForSeconds(isLifeTime);
        //Debug.Log("UnAct :: " + isLifeTime);
        gameObject.SetActive(false);
    }

    int i = 1;
    void Update()
    {
        if (isFrame)
        {
            if (i < LifeFrame)
                i++;
            else
            {
                i = 1;
                gameObject.SetActive(false);
            }
        }

    }
}
