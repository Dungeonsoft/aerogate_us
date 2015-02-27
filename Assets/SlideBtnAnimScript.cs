using UnityEngine;
using System.Collections;

public class SlideBtnAnimScript : MonoBehaviour
{

    void OnEnable()
    {
        GetComponent<UISprite>().spriteName = "Btn_PageR00";
        StartCoroutine(CursorAnim());

    }

    IEnumerator CursorAnim()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            GetComponent<UISprite>().spriteName = "Btn_PageR10";
            yield return new WaitForSeconds(0.2f);
            GetComponent<UISprite>().spriteName = "Btn_PageR20";
            yield return new WaitForSeconds(0.2f);
            GetComponent<UISprite>().spriteName = "Btn_PageR30";
            yield return new WaitForSeconds(0.2f);
            GetComponent<UISprite>().spriteName = "Btn_PageR40";
            yield return new WaitForSeconds(0.2f);
            GetComponent<UISprite>().spriteName = "Btn_PageR50";
        }
    }

}
