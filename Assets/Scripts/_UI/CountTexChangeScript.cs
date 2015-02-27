using UnityEngine;
using System.Collections;

public class CountTexChangeScript : MonoBehaviour
{

    public void Activate()
    {
        GetComponent<UISprite>().spriteName = "Count05";
        animation.Play("CountAni");
        StartCoroutine(ChangeTex());
    }

    IEnumerator ChangeTex()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<UISprite>().spriteName = "Count04";
        yield return new WaitForSeconds(1f);
        GetComponent<UISprite>().spriteName = "Count03";
        yield return new WaitForSeconds(1f);
        GetComponent<UISprite>().spriteName = "Count02";
        yield return new WaitForSeconds(1f);
        GetComponent<UISprite>().spriteName = "Count01";
    }
}
