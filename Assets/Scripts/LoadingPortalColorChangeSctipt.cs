using UnityEngine;
using System.Collections;

public class LoadingPortalColorChangeSctipt : MonoBehaviour {
    public Color[] portalColror;
    int levelNumber = 0;
    float lerpValue = 0;

	// Use this for initialization
	IEnumerator Start () 
    {
        GetComponent<UITexture>().color = portalColror[0];
        while (true)
        {
            levelNumber = 0;
            while (levelNumber < 7)
            {
                yield return StartCoroutine(ChangeClolor());
                levelNumber++;
            }
            yield return new WaitForSeconds(1f);
        }
	}

    IEnumerator ChangeClolor()
    {
        lerpValue = 0;
        while (lerpValue < 1)
        {
            GetComponent<UITexture>().color = Color.Lerp(portalColror[levelNumber], portalColror[levelNumber + 1],lerpValue);
            yield return null;
            lerpValue += Time.deltaTime * 0.5f;

            //Debug.Log("lerpValue  is  " + lerpValue);
        }
        GetComponent<UITexture>().color = Color.Lerp(portalColror[levelNumber], portalColror[levelNumber + 1], 1);
    }
	
}
